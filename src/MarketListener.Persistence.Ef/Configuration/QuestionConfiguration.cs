namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using MarketListener.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class QuestionConfiguration : EntityConfiguration<Question>
{
    public override void Configure(EntityTypeBuilder<Question> builder)
    {
        base.Configure(builder);        

        builder.Property(entity => entity.Title).HasMaxLength(255).IsRequired();

        //builder.Property(e => e.Tags)
        //    .HasConversion(
        //        v => string.Join(',', v),
        //        v => System.Text.Json.JsonSerializer.Deserialize<List<TagLabel>>(v));

        builder.OwnsMany(
            question => question.Tags,
            ownedOwnedNavigationBuilder => ownedOwnedNavigationBuilder.ToJson());

        //builder.OwnsOne(question => question.Tags, ownedNavigationBuilder =>
        //{
        //    ownedNavigationBuilder.ToJson();
        //});
    }
}