namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class WordConfiguration : EntityConfiguration<Word>
{
    public override void Configure(EntityTypeBuilder<Word> builder)
    {
        base.Configure(builder);        

        builder.Property(entity => entity.Text).HasMaxLength(255).IsRequired();

        builder.OwnsOne(Word => Word.Tags, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
        });
    }
}