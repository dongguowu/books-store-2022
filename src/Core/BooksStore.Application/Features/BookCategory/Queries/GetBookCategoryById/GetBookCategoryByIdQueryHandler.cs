using AutoMapper;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;

public class GetBookCategoryByIdQueryHandler : IRequestHandler<GetBookCategoryByIdQuery, BookCategoryDetailDto?>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;


    public GetBookCategoryByIdQueryHandler(IReadRepository<Domain.Entities.BookCategory> rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;
    }

    public async Task<BookCategoryDetailDto?> Handle(GetBookCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        return _mapper.Map<BookCategoryDetailDto>(await _rep.GetByIdAsync(request.Id, cancellationToken));
    }
}
