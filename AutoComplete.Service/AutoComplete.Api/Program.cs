using AutoComplete.Business;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog( ( context, services, configuration ) => configuration
    .ReadFrom.Configuration( context.Configuration )
    .ReadFrom.Services( services )
    .Enrich.FromLogContext() );


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
    return new ElasticsearchSinkOptions( new Uri( config["ElcConfigration:Uri"] ) )
    {
        AutoRegisterTemplate = true, IndexFormat = $"AutoCompleteService"
    };
}
