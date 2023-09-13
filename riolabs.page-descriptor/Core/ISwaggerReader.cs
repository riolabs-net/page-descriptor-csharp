using Microsoft.OpenApi.Models;
using Riolabs.PageDescriptor.Services.SwaggerReader;

namespace Riolabs.PageDescriptor.Core;

public interface ISwaggerReader
{
    OpenApiDocument GetOrLoadDocument(string fname);
    List<MethodDefinition> GetPaths(string fname);
    List<SchemaDefinition> GetSchemas(string fname);
}