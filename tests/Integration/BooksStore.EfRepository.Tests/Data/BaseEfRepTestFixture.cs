﻿using BooksStore.Domain.Entities;
using BooksStore.Infra.Data.Context;
using BooksStore.Infra.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace BooksStore.EfRepository.Tests.Data;

public abstract class BaseEfRepTestFixture
{
    protected AppDbContext? DbContext;

    protected BaseEfRepTestFixture()
    {
        DbContext = null;
    }

    protected void RefreshDatabase()
    {
        DbContext = new AppDbContext(CreateNewContextOptions(), new Mock<IMediator>().Object);
    }

    protected EfRepository<Book> GetRepository()
    {
        return new EfRepository<Book>(DbContext);
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
        var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionBuilder.UseInMemoryDatabase("booksStore")
            .UseInternalServiceProvider(serviceProvider);

        return optionBuilder.Options;
    }
}
