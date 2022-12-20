﻿namespace MarketListener.Persistence.Ef.Configurations;

using MarketListener.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class EntityConfiguration<TEntity> : DbSchemaConfiguration<TEntity>, IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey("Id");
    }
}