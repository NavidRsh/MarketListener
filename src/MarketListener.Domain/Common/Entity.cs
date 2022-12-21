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
    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }    
}