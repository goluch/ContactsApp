using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;
public abstract class BaseValueObject<T> : ValueObject
{
    public T Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = new();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
