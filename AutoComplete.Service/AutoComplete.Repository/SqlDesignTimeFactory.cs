namespace AutoComplete.Repository;

using DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


public class SqlDesignTimeFactory : IDesignTimeDbContextFactory<CarAutoCompleteDbContext>
{
    public CarAutoCompleteDbContext CreateDbContext( string[] args )
    {
        var config = new ConfigurationBuilder().SetBasePath( Directory.GetCurrentDirectory() ).AddJsonFile( "appsettings.json" )
            .Build();

        var builder = new DbContextOptionsBuilder().UseSqlServer( config.GetConnectionString( "msSql" ) );
        return new CarAutoCompleteDbContext(builder.Options);
    }
}
