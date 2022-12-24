namespace MarketListener.Application.Common.Mappings;

using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class MapsterConfig
{
    public static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig(); 
        //config.NewConfig<LivePriceChangeCommand, LivePrice>()
        //    .Map(dest => dest.Key, src => $"{src.Type}:{src.InsMaxLcode}")
        //    .Map(dest => dest.RegisterDate, src => System.DateTime.Now);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services; 
    }
}
