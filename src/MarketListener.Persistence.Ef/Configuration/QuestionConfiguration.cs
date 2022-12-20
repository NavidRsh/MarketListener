namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class QuestionConfiguration : EntityConfiguration<Question>
{
    public override void Configure(EntityTypeBuilder<Question> builder)
    {
        base.Configure(builder);        

        builder.Property(entity => entity.Title).HasMaxLength(255).IsRequired();

        builder.OwnsOne(question => question.Tags, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
        });
    }
}