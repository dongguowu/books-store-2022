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
            new("category 01"), new("category 02"), new("category 03"), new("category 04")
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
