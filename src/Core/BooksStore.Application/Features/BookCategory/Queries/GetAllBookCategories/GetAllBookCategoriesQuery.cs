using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public sealed record GetAllBookCategoriesQuery(string? QueryString = null) : IRequest<List<BookCategoryDto>>;
