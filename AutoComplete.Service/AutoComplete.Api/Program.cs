using AutoComplete.Business;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog( ( context, services, configuration ) => configuration
    .ReadFrom.Configuration( context.Configuration )
    .ReadFrom.Services( services )
    .Enrich.FromLogContext() );

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// Add services to the container.
builder.Services.AddBusiness();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSerilogRequestLogging( configure =>
{
    configure.IncludeQueryInRequestPath = true;
    configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
} ); // We want to log all HTTP requests

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiVersioning();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





void ConfigLogs()
{

    var config =
        new ConfigurationBuilder().AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true ).Build();


    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug(  )
        .WriteTo.Console( )
        .WriteTo.Elasticsearch( ConfigureEls( config )  )
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureEls( IConfiguration config )
{
    return new ElasticsearchSinkOptions( new Uri( config["ElcConfiguration:Uri"] ) )
    {
        AutoRegisterTemplate = true, IndexFormat = $"AutoCompleteService"
    };
}
