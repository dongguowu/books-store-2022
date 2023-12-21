using MediatR;

namespace BooksStore.Domain.Core.Events;

public class Message : IRequest<bool>
{
    public Message()
    {
        MessageType = GetType().Name;
    }

    public string MessageType { get; protected set; }
}
