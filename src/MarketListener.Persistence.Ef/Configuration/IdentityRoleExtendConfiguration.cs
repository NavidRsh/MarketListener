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

public class IdentityRoleExtendConfiguration : IEntityTypeConfiguration<IdentityRoleExtend>
{
    public void Configure(EntityTypeBuilder<IdentityRoleExtend> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(new IdentityRoleExtend
        {
            Id = 1,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        }, new IdentityRoleExtend
        {
            Id = 2,
            Name = "Supporter",
            NormalizedName = "SUPPORTER"
        }, new IdentityRoleExtend
        {
            Id = 3,
            Name = "User",
            NormalizedName = "USER"
        }
        );
    }
}
