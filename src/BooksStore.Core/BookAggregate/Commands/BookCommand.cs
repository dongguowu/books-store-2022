using BooksStore.Domain.Core.Commands;

namespace BooksStore.Core.BookAggregate.Commands;
public abstract class BookCommand : Command
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
}
