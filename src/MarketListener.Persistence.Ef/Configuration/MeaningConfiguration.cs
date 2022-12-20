namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public sealed class MeaningConfiguration : EntityConfiguration<Meaning>
{
    public override void Configure(EntityTypeBuilder<Meaning> builder)
    {
        base.Configure(builder);                
    }
}