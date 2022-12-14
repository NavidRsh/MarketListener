namespace MarketListener.Persistence.Ef;

using MarketListener.Persistence.Ef.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StartupModule
{
    public static IServiceCollection AddPersistenceEfServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BaseConnection"), b =>
            {
                b.MigrationsAssembly(typeof(StartupModule).Assembly.GetName().Name);
            });
        });

        return services;
    }
}
