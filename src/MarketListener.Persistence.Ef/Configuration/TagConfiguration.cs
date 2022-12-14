namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class TagConfiguration : EntityConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.Parent).WithMany()
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(new Tag() { 
            Id = 1, 
            Name = "General",
            ParentId = null,
            PersianName = "عمومی",
            Category = ""
        }); 
    }
}