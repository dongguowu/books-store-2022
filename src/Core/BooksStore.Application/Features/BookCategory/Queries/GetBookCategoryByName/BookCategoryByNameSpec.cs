using Ardalis.Specification;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;

public class BookCategoryByNameSpec : Specification<Domain.Entities.BookCategory>, ISingleResultSpecification
{
    public BookCategoryByNameSpec(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Query.Where(category => category.Name.Equals(name));
        }
    }
}
