using Ardalis.Specification;

namespace BooksStore.Core.BookAggregate.Specifications;

public class BookByIdSpec : Specification<Book>, ISingleResultSpecification
{
  public BookByIdSpec(Guid id)
  {
    Query.Where(book => book.Id == id);
  }
}
