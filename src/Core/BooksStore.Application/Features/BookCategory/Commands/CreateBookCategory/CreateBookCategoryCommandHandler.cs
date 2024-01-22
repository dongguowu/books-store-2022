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


    public CreateBookCategoryCommandHandler(IReadRepository<Domain.Entities.BookCategory> readRep, IRepository<Domain.Entities.BookCategory> writeRep, IMapper mapper)
    {
        _writeRep = writeRep;
        _readRep = readRep;
        _mapper = mapper;
    }

    public async Task<BookCategoryDto> Handle(CreateBookCategoryCommand request, CancellationToken cancellationToken)
    {
        //0 validate incoming data
        var validator = new CreateOrUpdateBookCategoryValidator(_readRep, _mapper);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid BookCategory", validationResult);
        }

        //2 add to database
        var bookCategory = await _writeRep.AddAsync(_mapper.Map<Domain.Entities.BookCategory>(request), cancellationToken);


        //3 return record 
        return _mapper.Map<BookCategoryDto>(bookCategory);
    }
}
