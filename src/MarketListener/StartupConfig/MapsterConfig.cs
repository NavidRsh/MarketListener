namespace MarketListener.StartupConfig;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
public static class MapsterConfig
{
    public static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
       
        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();

        return services; 
    }
}
