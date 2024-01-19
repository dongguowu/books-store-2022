using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;

public class
    GetBookCategoryByNameQueryHandler : IRequestHandler<GetBookCategoryByNameQuery, BookCategoryDetailDto?>
{
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;
    private readonly IMapper _mapper;

    public GetBookCategoryByNameQueryHandler(IReadRepository<Domain.Entities.BookCategory> rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public async Task<BookCategoryDetailDto?> Handle(GetBookCategoryByNameQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new BookCategoryByNameSpec(request.Name);

        var bookCategory = await _rep.GetBySpecAsync(spec, cancellationToken);

        return _mapper.Map <BookCategoryDetailDto>(bookCategory);
    }
}
