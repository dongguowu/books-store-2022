using MediatR;

namespace BooksStore.Domain.Core.Events
{
    public class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
