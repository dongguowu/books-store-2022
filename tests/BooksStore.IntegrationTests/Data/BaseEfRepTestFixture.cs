using BooksStore.Core.BookAggregate;
using BooksStore.Infra.Data.Context;
using BooksStore.Infra.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BooksStore.IntegrationTests.Data;

public abstract class BaseEfRepTestFixture
{
  protected AppDbContext _dbContext;

  protected void RefreshDatabase()
  {
    _dbContext = new AppDbContext(CreateNewContextOptions(), (new Mock<IMediator>()).Object);
  }

  protected EfRepository<Book> GetRepository()
  {
    return new EfRepository<Book>(_dbContext);
  }
  private static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<AppDbContext>();
    builder.UseInMemoryDatabase("booksStore")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

}
