using AutoMapper;
using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Interfaces.Shared;
using MediatR;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;

public class UpdateBookCategoryCommandHandler : IRequestHandler<UpdateBookCategoryCommand, bool>
{
    private readonly IAppLogger<UpdateBookCategoryCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _readRep;
    private readonly IRepository<Domain.Entities.BookCategory> _writeRep;

    public UpdateBookCategoryCommandHandler(IReadRepository<Domain.Entities.BookCategory> readRep,
        IRepository<Domain.Entities.BookCategory> writeRep, IMapper mapper,
        IAppLogger<UpdateBookCategoryCommandHandler> logger)
    {
        _readRep = readRep;
        _writeRep = writeRep;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        //0.1 validate incoming data
        var validator = new CreateOrUpdateBookCategoryValidator(_readRep, _mapper);
        var validationResult =
            await validator.ValidateAsync(new CreateBookCategoryCommand(request.Name), cancellationToken);
        if (validationResult.Errors.Any())
        {
            var message = "Invalid BookCategory";
            _logger.LogWarning("....My Logger Information.....");
            _logger.LogWarning(message);
            throw new BadRequestException(message, validationResult);
        }

        //0.2 does the book category exists
        var bookCategoryToUpdate = await _writeRep.GetByIdAsync(request.Id, cancellationToken) ??
                                   throw new NotFoundException(nameof(BookCategory), request.Id);

        // 1 Update
        bookCategoryToUpdate.Name = request.Name;
        await _writeRep.UpdateAsync(bookCategoryToUpdate, cancellationToken);

        return true;
    }
}
