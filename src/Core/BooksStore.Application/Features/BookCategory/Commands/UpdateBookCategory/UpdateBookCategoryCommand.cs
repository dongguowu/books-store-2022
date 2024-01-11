using MediatR;

namespace BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;

public sealed record UpdateBookCategoryCommand(Guid Id, string Name) : IRequest<Unit>, IRequest<bool>;
