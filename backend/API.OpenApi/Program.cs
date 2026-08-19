using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy
        {
            ProcessDictionaryKeys = true
        }
    }
};

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services
    .AddOpenApiDocument(document =>
    {
        document.DocumentName = "SettingsHub";
        document.Title =
            "ReactivitiesV1"; // Official interface name. No spaces. PascalCase.
        document.Version = "1.0.0";
        document.DefaultResponseReferenceTypeNullHandling = NJsonSchema.Generation.ReferenceTypeNullHandling.NotNull;

        // If you need non-RPC/event models included in the spec, add a DocumentProcessor here
        // similar to the sample you provided (NonRpcTypesProcessor).
    });

var pluginAssembly = Assembly.GetAssembly(typeof(API.Program));
services.AddMvc()
    .AddApplicationPart(pluginAssembly!)
    .AddControllersAsServices()
    .AddNewtonsoftJson(o =>
    {
        o.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true
            }
        };
    });

// Mock controller dependencies (keep this list in sync with controller constructors)

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.Run();

public sealed class NonRpcTypesProcessor(Type[] types) : IDocumentProcessor
{
    public void Process(DocumentProcessorContext context)
    {
        foreach (var type in types)
        {
            if (!context.SchemaResolver.HasSchema(type, false))
            {
                context.SchemaGenerator.Generate(type, context.SchemaResolver);
            }
        }
    }
}
