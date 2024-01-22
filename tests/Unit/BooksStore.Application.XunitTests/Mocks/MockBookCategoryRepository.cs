using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Interfaces;

namespace BooksStore.Application.XunitTests.Mocks;

public class MockBookCategoryRepository
{
    public static readonly List<BookCategory> _list = new()
    {
        new BookCategory("category 01"), new BookCategory("category 02"), new BookCategory("category 03")
    };

    public static Mock<IReadRepository<BookCategory>> GetReadRepositoryWithDefaultList()
    {
        var mockRep = new Mock<IReadRepository<BookCategory>>();

        mockRep
            .Setup(r => r.ListAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(_list);

        return mockRep;
    }

    public static Mock<IRepository<BookCategory>> GetWriteRepositoryWithDefaultList()
    {
        var mockRepo = new Mock<IRepository<BookCategory>>();

        mockRepo
            .Setup(r => r.AddAsync(It.IsAny<BookCategory>(), It.IsAny<CancellationToken>()))
            .Returns((BookCategory bookCategory, CancellationToken cancellation) =>
            {
                _list.Add(bookCategory);
                return Task.FromResult(bookCategory);
            });

        return mockRepo;
    }
}
