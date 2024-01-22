using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public sealed record GetAllBookCategoriesQuery : IRequest<List<BookCategoryDto>>;
