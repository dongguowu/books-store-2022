using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
