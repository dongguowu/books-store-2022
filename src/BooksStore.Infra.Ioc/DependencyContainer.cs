using BooksStore.Core.BookAggregate;
using BooksStore.Core.Interfaces;
using BooksStore.Core.Services;
using BooksStore.Infra.Data.Repository;
using BooksStore.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BooksStore.Infra.Ioc;

public class DependencyContainer
{
  public static void RegisterServices(IServiceCollection services)
  {
    //Application Layer 
    services.AddScoped<IBookSearchService, BookSearchService>();

    //Infra.Data Layer
    services.AddScoped<IRepository<Book>, EfRepository<Book>>();
  }

}
