namespace SharedKernel;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public List<BaseDomainEvent> Events = new();

    protected BaseEntity(Guid id) => Id = id;

    protected BaseEntity() { }
}
