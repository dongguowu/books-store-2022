using AutoMapper;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public class GetBookCategoryQueryHandler : IRequestHandler<GetBookCategoryQuery, List<BookCategoryDto>>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;

    public GetBookCategoryQueryHandler(IMapper mapper, IReadRepository<Domain.Entities.BookCategory> rep)
    {
        this._mapper = mapper;
        this._rep = rep;
        
    }
    public async Task<List<BookCategoryDto>> Handle(GetBookCategoryQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var bookCategories = await _rep.ListAsync(cancellationToken);

        // convert data objects to DTO objects
        var data = _mapper.Map<List<BookCategoryDto>>(bookCategories);

        // return list of DTO objects
        return data;
    }
}
