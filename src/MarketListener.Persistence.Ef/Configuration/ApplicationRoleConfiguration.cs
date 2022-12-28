namespace MarketListener.Persistence.Ef.Configuration;

using MarketListener.Persistence.Ef.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicaitonRole>
{
    public void Configure(EntityTypeBuilder<ApplicaitonRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(new ApplicaitonRole
        {
            Id = 1,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        }, new ApplicaitonRole
        {
            Id = 2,
            Name = "Supporter",
            NormalizedName = "SUPPORTER"
        }, new ApplicaitonRole
        {
            Id = 3,
            Name = "User",
            NormalizedName = "USER"
        }
        );
    }
}
