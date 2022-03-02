using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Domain.Core.Events;

namespace BooksStore.Domain.Core.Commands;
public abstract class Command : Message
{
  public DateTime Timestamp { get; set; }
  protected Command()
  {
    Timestamp = DateTime.Now; 
  }
}
