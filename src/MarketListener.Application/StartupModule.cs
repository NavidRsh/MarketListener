namespace MarketListener.Application;

using FluentValidation;
using FluentValidation.AspNetCore;
using MarketListener.Application.Common.Behaviours;
using MarketListener.Application.Common.Mappings;
using MarketListener.Application.Gateways.AuthManager;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public static class StartupModule
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

        services.RegisterMapsterConfiguration(); 

        services.Configure<SieveOptions>(configuration);

        services.AddScoped<SieveProcessor>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        return services;
    }
}
