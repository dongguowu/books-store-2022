using BooksStore.Domain.Commands;

namespace BooksStore.Domain.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
}
