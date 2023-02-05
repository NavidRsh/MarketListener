namespace MarketListener.Domain.Common;

using Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

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

    private List<DomainEventBase> _domainEvents = new();
    //[NotMapped]
    //public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    internal void ClearDomainEvents() => _domainEvents.Clear();
    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }    
}