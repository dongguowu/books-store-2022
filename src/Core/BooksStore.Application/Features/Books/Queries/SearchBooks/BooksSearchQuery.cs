using BooksStore.Domain.Entities;
using MediatR;

namespace BooksStore.Application.Features.Books.Queries.SearchBooks;

public sealed record BooksSearchQuery(string SearchStr) : IRequest<List<Book>>;
