namespace MarketListener.Persistence.Ef;

using MarketListener.Application.Gateways.AuthManager;
using MarketListener.Application.Gateways.Repositories;
using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Application.Gateways.Repositories.User;
using MarketListener.Domain.Entities;
using MarketListener.Persistence.Ef.Data;
using MarketListener.Persistence.Ef.Data.Repositories;
using MarketListener.Persistence.Ef.Data.Repositories.Question;
using MarketListener.Persistence.Ef.Data.Repositories.User;
using MarketListener.Persistence.Ef.IdentityEntities;
using MarketListener.Persistence.Ef.StartupConfig;
using Microsoft.AspNetCore.Identity;
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

        services.AddScoped<IAuthManager, AuthManager>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepositories(); 

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicaitonRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();

        return services;
    }
}
