using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using MediatR;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;

public class CreateBookCategoryCommandHandler : IRequestHandler<CreateBookCategoryCommand, BookCategoryDto>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _readRep;
    private readonly IRepository<Domain.Entities.BookCategory> _writeRep;


    public CreateBookCategoryCommandHandler(IRepository<Domain.Entities.BookCategory> writeRep, IMapper mapper,
        IReadRepository<Domain.Entities.BookCategory> readRep)
    {
        _writeRep = writeRep;
        _mapper = mapper;
        _readRep = readRep;
    }

    public async Task<BookCategoryDto> Handle(CreateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        //0 validate incoming data
        var validator = new CreateBookCategoryValidator(_readRep);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid BookCategory", validationResult);
        }

        //1 convert to domain entity object
        var bookCategoryToCreate = _mapper.Map<Domain.Entities.BookCategory>(request);

        //2 add to database
        var bookCategory = await _writeRep.AddAsync(bookCategoryToCreate, cancellationToken);
        await _writeRep.SaveChangesAsync(cancellationToken);


        //3 return record id
        return _mapper.Map<BookCategoryDto>(bookCategory);
    }
}
