using BooksStore.Domain.Core.Events;

namespace BooksStore.Domain.Core.Commands;

public abstract class Command : Message
{
    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; set; }
}
