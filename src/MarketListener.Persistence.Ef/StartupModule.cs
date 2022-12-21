namespace MarketListener.Persistence.Ef;

using MarketListener.Application.Gateways.Repositories;
using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Persistence.Ef.Data;
using MarketListener.Persistence.Ef.Data.Repositories;
using MarketListener.Persistence.Ef.Data.Repositories.Question;
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

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();

        return services;
    }
}
