using AutoMapper;
using MediatR;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;

public class UpdateBookCategoryCommandHandler : IRequestHandler<UpdateBookCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.Entities.BookCategory> _rep;

    public UpdateBookCategoryCommandHandler(IMapper mapper, IRepository<Domain.Entities.BookCategory> rep)
    {
        _mapper = mapper;
        _rep = rep;
    }

    public async Task<bool> Handle(UpdateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        // validate incoming data

        //0.2 does the book category exists
        var bookCategoryToUpdate = await _rep.GetByIdAsync(request.Id, cancellationToken) ??
                                   throw new NotFoundException(nameof(BookCategory), request.Id);
        bookCategoryToUpdate.Name = request.Name;

        await _rep.UpdateAsync(bookCategoryToUpdate, cancellationToken);
        await _rep.SaveChangesAsync(cancellationToken);

        return true;
    }
}
