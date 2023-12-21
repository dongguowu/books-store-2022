using Ardalis.Specification;

namespace BooksStore.Core.BookAggregate.Specifications;

public class BooksSearchSpec : Specification<Book>
{
    public BooksSearchSpec(string searchString)
    {
        Query
            .Where(book => book.Title.Contains(searchString) || book.Category.Contains(searchString));
    }
}
