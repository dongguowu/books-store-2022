using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.Specification;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
public class BookCategoriesContainNameSpec : Specification<Domain.Entities.BookCategory>
{
    public BookCategoriesContainNameSpec(string? queryString)
    {
        Query.Where(c => String.IsNullOrWhiteSpace(queryString)|| c.Name.Contains(queryString));

    }
}
