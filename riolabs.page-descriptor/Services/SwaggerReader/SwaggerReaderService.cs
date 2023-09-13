using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Riolabs.PageDescriptor.Core;
using System.Text;

namespace Riolabs.PageDescriptor.Services.SwaggerReader;

public class SwaggerReaderService : ISwaggerReader
{
    private readonly Dictionary<string, OpenApiDocument> _openApiDocuments;

    public OpenApiDocument GetOrLoadDocument(string fname)
    {
        if (_openApiDocuments.TryGetValue(fname, out var document))
        {
            return document;
        }
        else
        {
            string swaggerJson = string.Empty;
            using (var streamReader = new StreamReader(fname, Encoding.UTF8))
            {
                swaggerJson = streamReader.ReadToEnd();
            }
            var _doc = new OpenApiStringReader().Read(swaggerJson, out _);
            _openApiDocuments.Add(fname, _doc);
            return _doc;
        }
    }

    public List<MethodDefinition> GetPaths(string fname)
    {
        var paths = GetOrLoadDocument(fname).Paths
            .SelectMany(o => o.Value.Operations, (i, v) => new MethodDefinition
            {
                Path = i.Key,
                Verb = v.Key.ToString(),
                Params = v.Value.Parameters.Select(p => new ParameterDefinition
                {
                    Name = p.Name,
                    Required = p.Required,
                    Type = p.Schema.Type,
                    Example = p.Example?.ToString(),
                    In = p.In
                }).ToList(),
                Responses = v.Value.Responses.Select(r =>
                {
                    var ret = new ResponseDefinition
                    {
                        Status = int.Parse(r.Key),
                        Description = r.Value.Description,
                    };
                    if (r.Value.Content.Count > 0)
                    {
                        ret.Type = r.Value.Content.FirstOrDefault().Value.Schema.Type;
                        if (r.Value.Content.FirstOrDefault().Value.Schema.Type == "array")
                        {
                            ret.SchemaId = r.Value.Content.FirstOrDefault().Value.Schema.Items.Reference.Id;
                            ret.Schema = GetSchemas(fname).FirstOrDefault(s => s.SchemaId == ret.SchemaId);
                        }
                        else
                        {
                            ret.SchemaId = r.Value.Content.FirstOrDefault().Value.Schema.Reference.Id;
                            ret.Schema = GetSchemas(fname).FirstOrDefault(s => s.SchemaId == ret.SchemaId);
                        }
                    }
                    return ret;
                }).ToList()
            });
        return paths.ToList();
    }

    public List<SchemaDefinition> GetSchemas(string fname)
    {
        var i = new List<SchemaDefinition>();
        foreach (var schema in GetOrLoadDocument(fname).Components.Schemas)
        {
            var _schema = new SchemaDefinition
            {
                SchemaId = schema.Key,
                Type = schema.Value.Type,
                RequiredFields = schema.Value.Required.ToArray(),
                Properties = schema.Value.Properties.Select(p => new SchemaPropDefinition
                {
                    Name = p.Key,
                    Type = p.Value.Type,
                    Example = p.Value.Example?.ToString(),
                    Format = p.Value.Format,
                    Nullable = p.Value.Nullable,
                    Meta = p.Value.Extensions.ToDictionary(p => p.Key[2..], p => p.Value)
                }).ToList(),
                Meta = schema.Value.Extensions.ToDictionary(p => p.Key[2..], p => p.Value)
            };
            i.Add(_schema);
        }
        return i;
    }
}
