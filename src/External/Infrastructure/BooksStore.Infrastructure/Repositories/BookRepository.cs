using Ardalis.Specification;
using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;
using SharedKernel.Interfaces;

namespace BooksStore.Infrastructure.Repositories;

public sealed class BookRepository : EfRepository<Book>
{
    public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
