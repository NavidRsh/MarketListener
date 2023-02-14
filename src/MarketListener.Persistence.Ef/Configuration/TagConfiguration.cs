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
        builder.HasData(Tag.Create(9, "IELTS General Band Score 8", "نمره ۸ آیلتس جنرال", "IEL-GE-8", "", 4));
        builder.HasData(Tag.Create(10, "IELTS General Band Score 7", "نمره ۷ آیلتس جنرال", "IEL-GE-7", "", 4));
        builder.HasData(Tag.Create(11, "IELTS General Band Score 6", "نمره ۶ آیلتس جنرال", "IEL-GE-6", "", 4));
        builder.HasData(Tag.Create(12, "IELTS General Band Score 5", "نمره ۵ آیلتس جنرال", "IEL-GE-5", "", 4));

        builder.HasData(Tag.Create(21, "IELTS Academic Speaking", "مکالمه آیلتس جنرال", "IEL-AC-SP", "", 3));
        builder.HasData(Tag.Create(22, "IELTS Academic Listening", "شنیداری آیلتس جنرال", "IEL-AC-LI", "", 3));
        builder.HasData(Tag.Create(23, "IELTS Academic Writing", "نوشتاری آیلتس جنرال", "IEL-AC-WR", "", 3));
        builder.HasData(Tag.Create(24, "IELTS Academic Reading", "خواندنی آیلتس جنرال", "IEL-AC-RE", "", 3));

        builder.HasData(Tag.Create(26, "IELTS General Speaking", "مکالمه آیلتس جنرال", "IEL-GE-SP", "", 4));
        builder.HasData(Tag.Create(27, "IELTS General Listening", "شنیداری آیلتس جنرال", "IEL-GE-LI", "", 4));
        builder.HasData(Tag.Create(28, "IELTS General Writing", "نوشتاری آیلتس جنرال", "IEL-GE-WR", "", 4));
        builder.HasData(Tag.Create(29, "IELTS General Reading", "خواندنی آیلتس جنرال", "IEL-GE-RE", "", 4));

        builder.HasData(Tag.Create(101, "Travel", "مسافرت", "TRV", "", 1));
        builder.HasData(Tag.Create(102, "Greeting", "احوالپرسی", "GRT", "", 1));
        builder.HasData(Tag.Create(103, "Eating Out", "رستوران", "EAT", "", 1));
        builder.HasData(Tag.Create(104, "Airport", "فرودگاه", "APT", "", 1));
        builder.HasData(Tag.Create(105, "Working", "کار و مشاغل", "WRK", "", 1));

    }
}