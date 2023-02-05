namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class AnswerConfiguration : EntityConfiguration<Answer>
{
    public override void Configure(EntityTypeBuilder<Answer> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.Question)
            .WithMany(e => e.Answers)
            .OnDelete(DeleteBehavior.Restrict);
    }
}