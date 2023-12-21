namespace SharedKernel;

public abstract class BaseEntity
{
    private readonly List<BaseDomainEvent> _domainEvents = new();

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    protected BaseEntity() { }
    public Guid Id { get; protected set; } = Guid.NewGuid();

    //public List<BaseDomainEvent> DomainEvents = new();
    public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

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
