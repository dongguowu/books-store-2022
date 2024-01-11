using Ardalis.Specification;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.Features.Books.Queries.SearchBooks;

public sealed class BooksSearchSpec : Specification<Book>, ISingleResultSpecification
{
    public BooksSearchSpec(string? searchStr = null)
    {
        Query.Where(book => string.IsNullOrWhiteSpace(searchStr) || book.Title.Contains(searchStr) ||
                            book.Category.Name.Contains(searchStr));
    }
}
