using BooksStore.Domain.Entities;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.Books.Queries.SearchBooks;

public class BooksSearchQueryHandler : IRequestHandler<BooksSearchQuery, List<Book>>
{
    private readonly IReadRepository<Book> _rep;

    public BooksSearchQueryHandler(IReadRepository<Book> rep)
    {
        _rep = rep;
    }

    public async Task<List<Book>> Handle(BooksSearchQuery request, CancellationToken cancellationToken)
    {
        var spec = new BooksSearchSpec(request?.SearchStr);

        var list = await _rep.ListAsync(spec, cancellationToken);

        return list;
    }
}
