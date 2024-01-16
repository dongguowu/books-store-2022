using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Interfaces;

namespace BooksStore.Application.XunitTests.Mocks;

public class MockBookCategoryRepository
{
    public static Mock<IReadRepository<BookCategory>> GetReadRepository()
    {

        var list = new List<BookCategory>
        {
            new BookCategory("category 01"),
            new BookCategory("category 02"),
            new BookCategory("category 03"),
            new BookCategory("category 04"),
        };

        var mockRepo = new Mock<IReadRepository<BookCategory>>();

        mockRepo
            .Setup(r => r.ListAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(list);

        return mockRepo;
    }

    public static Mock<IRepository<BookCategory>> GetWriteRepository()
    {

        var list = new List<BookCategory>();

        var mockRepo = new Mock<IRepository<BookCategory>>();

        mockRepo
            .Setup(r => r.AddAsync(It.IsAny<BookCategory>(), It.IsAny<CancellationToken>()))
            .Returns((BookCategory bookCategory) =>
            {
                list.Add(bookCategory);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
