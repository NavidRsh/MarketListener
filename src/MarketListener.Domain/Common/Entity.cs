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
    public virtual TKey Id { get; protected set; }    
    public DateTime CreateTime { get; protected set; }
    public DateTime? ModifyTime { get; protected set; }
    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }    
}