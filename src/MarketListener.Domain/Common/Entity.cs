namespace MarketListener.Domain.Common;

using Interfaces;

public abstract class Entity
{
    public virtual Entity Clone()
    {
        return MemberwiseClone() as Entity;
    }
}

public abstract class Entity<TKey> : Entity, IEntity<TKey> where TKey : struct
{
    public virtual TKey Id { get; init; }

    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }    
}