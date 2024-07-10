using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Domain.Common;
public abstract class BaseEntity<T>
{
    public T Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = new();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
