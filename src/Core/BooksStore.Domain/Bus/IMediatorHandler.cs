using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Domain.Commands;

namespace BooksStore.Domain.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
}
