using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoComplete.Business.Implementation;
using AutoComplete.Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AutoComplete.Business;
public static class DependencyInjectionBusiness
{
    public static IServiceCollection AddBusiness( this IServiceCollection collection )
    {
        collection = AutoComplete.Repository.DependencyInjection.AddRepository( collection )
                .AddScoped<ICarManufacturerService, CarManufacturerService>()
                .AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() )
            ;
        return collection;
    }
}
