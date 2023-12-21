namespace BooksStore.Core.BookAggregate.Commands;

public class CreateBookCommand : BookCommand
{
    public CreateBookCommand(string title, string imageUrl, decimal price)
    {
        Title = title;
        Price = price;
        ImageUrl = imageUrl;
    }
}
