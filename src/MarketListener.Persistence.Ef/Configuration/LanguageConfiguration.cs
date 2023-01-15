using MarketListener.Domain.Entities;
using MarketListener.Persistence.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketListener.Persistence.Ef.Configuration
{
    public class LanguageConfiguration : EntityConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(5);

            builder.HasData(Language.Create(1, "English", "en"),
                Language.Create(2, "Persian", "fa")); 

            base.Configure(builder);
        }
    }
}
