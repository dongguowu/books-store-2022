using AutoMapper;
using BooksStore.Domain.Entities;
using MediatR;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IRepository<Book> _rep;

    public DeleteBookCommandHandler(IMapper mapper, IRepository<Book> rep)
    {
        _rep = rep;
    }


    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity object and verify that record exists
        //var bookToDelete = await _rep.GetByIdAsync(request.Id, cancellationToken) ?? throw new BookNotFoundException(request.Id);
        var bookToDelete = await _rep.GetByIdAsync(request.Id, cancellationToken);
        if (bookToDelete == null)
        {
            throw new NotFoundException(nameof(bookToDelete), request.Id);
        }

        // remove from database
        await _rep.DeleteAsync(bookToDelete, cancellationToken);

        // return
        return true;
    }
}
