using MediatR;

namespace SharedKernel;

public abstract class BaseDomainEvent : INotification
{
    public DateTime DateOccurred { get; set; } = DateTime.UtcNow;
}
