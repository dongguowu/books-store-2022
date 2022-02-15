using MediatR;

namespace BooksStore.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
  public DateTime dateOccurred { get; set; }  = DateTime.UtcNow;
}
