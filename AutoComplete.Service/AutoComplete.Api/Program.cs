using AutoComplete.Business;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);
ConfigLogs();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddBusiness();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

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
