using AutoComplete.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoComplete.Repository;

using Implementation;
using Interface;

using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddRepository( this IServiceCollection serviceCollection )
    {
        var config = new ConfigurationBuilder().SetBasePath( Directory.GetCurrentDirectory() ).AddJsonFile( "appsettings.json" )
            .Build();
        return serviceCollection.AddDbContext<CarAutoCompleteDbContext>( x =>
            x.UseSqlServer( config.GetConnectionString( "msSql" ) ) )
            .AddTransient<IRepositoryManager, RepositoryManager>();
       
    }
}
