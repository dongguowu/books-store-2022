namespace BooksStore.SharedKernel;

public abstract class BaseEntity
{
  public Guid Id { get; set; }
  public List<BaseDomainEvent> Events = new();
}
