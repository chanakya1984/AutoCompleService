namespace AutoComplete.Repository;

using Implementation;
using Interface;

using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddRepository( this IServiceCollection serviceCollection ) => serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
}
