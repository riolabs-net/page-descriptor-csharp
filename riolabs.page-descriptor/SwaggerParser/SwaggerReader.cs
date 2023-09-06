using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.SwaggerParser;
public class SwaggerReader
{
    private readonly OpenApiDocument _openApiDocument;

    public List<SchemaDefinition> Schemas { get; private set; }
    public List<MethodDefinition> Methods { get; private set; }

    public SwaggerReader(string swagger)
    {
        string swaggerJson = string.Empty;
        using (var streamReader = new StreamReader(swagger, Encoding.UTF8))
        {
            swaggerJson = streamReader.ReadToEnd();
        }

        var document = new OpenApiStringReader().Read(swaggerJson, out _);
        _openApiDocument = document;
        Schemas = GetSchemas();
        Methods = GetPaths();
    }

    public List<MethodDefinition> GetPaths()
    {
        var paths = _openApiDocument.Paths
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
                            ret.Schema = Schemas.FirstOrDefault(s => s.SchemaId == ret.SchemaId);
                        }
                        else
                        {
                            ret.SchemaId = r.Value.Content.FirstOrDefault().Value.Schema.Reference.Id;
                            ret.Schema = Schemas.FirstOrDefault(s => s.SchemaId == ret.SchemaId);
                        }
                    }
                    return ret;
                }).ToList()
            });
        return paths.ToList();
    }

    public List<SchemaDefinition> GetSchemas()
    {
        var i = new List<SchemaDefinition>();
        foreach (var schema in _openApiDocument.Components.Schemas)
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
