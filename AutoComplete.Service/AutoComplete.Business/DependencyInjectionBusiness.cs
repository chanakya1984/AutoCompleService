


namespace AutoComplete.Business;

using Implementation;
using Interface;

using Microsoft.Extensions.DependencyInjection;
using HashidsNet;


public static class DependencyInjectionBusiness
{
    public static IServiceCollection AddBusiness( this IServiceCollection collection )
    {
      
        collection = AutoComplete.Repository.DependencyInjection.AddRepository( collection )
                .AddScoped<ICarManufacturerService, CarManufacturerService>()
                .AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() )
                .AddSingleton<IHashids>(_ => new Hashids( "8203B45B-30D7-4440-A600-C7B00223FB5F",11))
            ;
        return collection;
    }
}
