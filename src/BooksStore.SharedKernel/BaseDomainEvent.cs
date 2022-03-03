using MediatR;

namespace BooksStore.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
    public DateTime DateOccurred { get; set; } = DateTime.UtcNow;
}
