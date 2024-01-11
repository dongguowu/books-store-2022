using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BooksStore.Domain.Events;

public class Message : IRequest<bool>
{
    public Message()
    {
        MessageType = GetType().Name;
    }

    public string MessageType { get; protected set; }
}
