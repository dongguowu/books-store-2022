using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;

public class
    GetBookCategoryByNameQueryHandler : IRequestHandler<GetBookCategoryByNameQuery, Domain.Entities.BookCategory?>
{
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;

    public GetBookCategoryByNameQueryHandler(IReadRepository<Domain.Entities.BookCategory> rep)
    {
        _rep = rep;
    }

    public async Task<Domain.Entities.BookCategory?> Handle(GetBookCategoryByNameQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new BookCategoryByNameSpec(request.Name);

        return await _rep.GetBySpecAsync(spec, cancellationToken);
    }
}
