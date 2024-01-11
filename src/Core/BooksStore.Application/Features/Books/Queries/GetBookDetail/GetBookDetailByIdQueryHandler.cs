using AutoMapper;
using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Entities;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.Books.Queries.GetBookDetail;

public sealed class GetBookDetailByIdQueryHandler : IQueryHandler<GetBookDetailByIdQuery, BookDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Book> _rep;

    public GetBookDetailByIdQueryHandler(IMapper mapper, IReadRepository<Book> rep)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _rep = rep ?? throw new ArgumentNullException(nameof(rep));
    }

    public async Task<BookDetailDto?> Handle(GetBookDetailByIdQuery? request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return null;
        }

        var book = await _rep.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<BookDetailDto>(book);
    }
}
