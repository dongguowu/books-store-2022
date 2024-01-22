using AutoMapper;
using BooksStore.Application.Interfaces.Shared;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public class GetAllBookCategoriesQueryHandler : IRequestHandler<GetAllBookCategoriesQuery, List<BookCategoryDto>>
{
    private readonly IAppLogger<GetAllBookCategoriesQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;

    public GetAllBookCategoriesQueryHandler(IReadRepository<Domain.Entities.BookCategory> rep, IMapper mapper,
        IAppLogger<GetAllBookCategoriesQueryHandler> logger)
    {
        _mapper = mapper;
        _rep = rep;
        _logger = logger;
    }

    public async Task<List<BookCategoryDto>> Handle(GetAllBookCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        // Query the database
        var bookCategories = await _rep.ListAsync(cancellationToken);

        // convert data objects to DTO objects
        var data = _mapper.Map<List<BookCategoryDto>>(bookCategories);

        // return list of DTO objects
        return data;
    }
}
