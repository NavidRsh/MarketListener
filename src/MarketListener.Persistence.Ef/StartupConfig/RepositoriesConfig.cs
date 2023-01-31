using MarketListener.Application.Gateways.Repositories.Question;
using MarketListener.Application.Gateways.Repositories.Tag;
using MarketListener.Application.Gateways.Repositories.User;
using MarketListener.Persistence.Ef.Data.Repositories.Question;
using MarketListener.Persistence.Ef.Data.Repositories.Tag;
using MarketListener.Persistence.Ef.Data.Repositories.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketListener.Persistence.Ef.StartupConfig
{
    internal static class RepositoriesConfig
    {
        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITagRepository, TagRepository>(); 

            return services; 
        }
    }
}
