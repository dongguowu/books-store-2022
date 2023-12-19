using MediatR;

namespace SharedKernel;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    private readonly List<BaseDomainEvent> _domainEvents = new();

    //public List<BaseDomainEvent> DomainEvents = new();
    public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected BaseEntity(Guid id) => Id = id;

    protected BaseEntity() { }

    public void AddDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void DomainEventClear()
    {
        _domainEvents.Clear();
    }



}
