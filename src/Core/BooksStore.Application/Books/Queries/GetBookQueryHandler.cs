using System.Data;
using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Exceptions;
using Dapper;

namespace BooksStore.Application.Books.Queries;
internal sealed class GetBookQueryHandler : IQueryHandler<GetBookByIdQuery, BookResponse>
{
    private readonly IDbConnection _dbConnection;

    public GetBookQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        const string sql = @"SELECT * FROM ""books"" WHERE ""Id"" = @BookId";

        var book = await _dbConnection.QueryFirstOrDefaultAsync<BookResponse>(sql, new { request.BookId });

        return book ?? throw new BookNotFoundException(request.BookId);
    }
}
