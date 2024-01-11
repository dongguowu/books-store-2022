using BooksStore.Domain.Events;

namespace BooksStore.Domain.Commands;

public abstract class Command : Message
{
    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; set; }
}
