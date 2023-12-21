using BooksStore.Domain.Core.Commands;

namespace BooksStore.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
}
