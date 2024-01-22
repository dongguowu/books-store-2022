using AutoMapper;
using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Interfaces.Shared;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;

public class UpdateBookCategoryCommandHandler : IRequestHandler<UpdateBookCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Domain.Entities.BookCategory> _rep;
    private readonly IReadRepository<Domain.Entities.BookCategory> _readRep;
    private readonly IAppLogger<UpdateBookCategoryCommandHandler> _logger;

    public UpdateBookCategoryCommandHandler(IMapper mapper, IRepository<Domain.Entities.BookCategory> rep, IAppLogger<UpdateBookCategoryCommandHandler> logger, IReadRepository<Domain.Entities.BookCategory> readRep)
    {
        _mapper = mapper;
        _rep = rep;
        _logger = logger;
        _readRep = readRep;
    }

    public async Task<bool> Handle(UpdateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        //0.1 validate incoming data
        var validator = new CreateOrUpdateBookCategoryValidator(_readRep, _mapper);
        var validationResult =await validator.ValidateAsync(new CreateBookCategoryCommand(request.Name), cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid BookCategory", validationResult);
        }

        //0.2 does the book category exists
        var bookCategoryToUpdate = await _rep.GetByIdAsync(request.Id, cancellationToken) ??
                                   throw new NotFoundException(nameof(BookCategory), request.Id);

        // 1 Update
        bookCategoryToUpdate.Name = request.Name;
        await _rep.UpdateAsync(bookCategoryToUpdate, cancellationToken);

        return true;
    }
}
