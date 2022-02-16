using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
