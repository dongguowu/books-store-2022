using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;
public record GetBookCategoryByIdQuery(Guid Id) : IRequest<BookCategoryDetailDto>
{
}
