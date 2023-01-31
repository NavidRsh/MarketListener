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

        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(e => e.Code).HasMaxLength(10);

        builder.HasOne(e => e.Parent).WithMany()
            .HasForeignKey(e => e.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(Tag.Create(1, "General", "عمومی", "GNR", "", null));
        builder.HasData(Tag.Create(2, "IELTS", "آزمون آیلتس", "IEL", "", null));
        builder.HasData(Tag.Create(3, "IELTS Academic", "آزمون آیلتس", "IEL-AC", "", 2));
        builder.HasData(Tag.Create(4, "IELTS General", "آزمون آیلتس", "IEL-GNR", "", 2));
        builder.HasData(Tag.Create(5, "IELTS Academic Band Score 8", "نمره ۸ آیلتس", "IEL-AC-8", "", 3));
        builder.HasData(Tag.Create(6, "IELTS Academic Band Score 7", "نمره ۷ آیلتس", "IEL-AC-7", "", 3));
        builder.HasData(Tag.Create(7, "IELTS Academic Band Score 6", "نمره ۶ آیلتس", "IEL-AC-6", "", 3));
        builder.HasData(Tag.Create(8, "IELTS Academic Band Score 5", "نمره ۵ آیلتس", "IEL-AC-5", "", 3));

    }
}