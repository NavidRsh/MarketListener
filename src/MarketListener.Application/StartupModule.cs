namespace MarketListener.Application;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class StartupModule
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        return services; 
    }
}
