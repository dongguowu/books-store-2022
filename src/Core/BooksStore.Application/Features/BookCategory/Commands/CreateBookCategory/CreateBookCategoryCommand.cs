using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using MediatR;

namespace BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;

public sealed record CreateBookCategoryCommand(string Name) : IRequest<BookCategoryDto>;
