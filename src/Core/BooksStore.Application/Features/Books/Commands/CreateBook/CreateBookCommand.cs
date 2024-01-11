using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Entities;
using MediatR;

namespace BooksStore.Application.Features.Books.Commands.CreateBook;

public sealed record CreateBookCommand(string Title) : IRequest<Book>;
