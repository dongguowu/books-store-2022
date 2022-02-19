using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace BooksStore.Core.BookAggregate.Specifications;

public class BookByIdSpec : Specification<Book>, ISingleResultSpecification
{
  public BookByIdSpec(Guid id)
  {
    Query.Where(book => book.Id == id);
  }
}
