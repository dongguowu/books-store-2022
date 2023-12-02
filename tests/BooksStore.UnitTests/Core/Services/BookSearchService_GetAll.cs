using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.Services;
using Moq;
using NUnit.Framework;
using SharedKernel.Interfaces;

namespace BooksStore.UnitTests.Core.Services;

[TestFixture]
public class BookSearchService_GetAll
{
    private readonly Mock<IReadRepository<Book>> _mockRepo = new();
    private BookSearchService? _searchService;

    [SetUp]
    public void Init()
    {
        _searchService = new BookSearchService(_mockRepo.Object);
    }

    [TestCase()]
    public async Task ReturnsList()
    {
        var title = "a test book";
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<System.Threading.CancellationToken>())).ReturnsAsync(
          new List<Book>() { new Book(title, 23.31m), new Book(title, 23.31m) });

        var result = await _searchService!.GetAllBooks();

        Assert.That(result.Status, Is.EqualTo(Ardalis.Result.ResultStatus.Ok));
        Assert.That(result.Value.Count, Is.EqualTo(2));
        Assert.That(result.Value[0].Title, Is.EqualTo(title));
        Assert.That(result.Value[1].Title, Is.EqualTo(title));
    }

    [TestCase()]
    public void ReturnsError()
    {
        string expectedErrorMessage = "Database not there.";
        var exception = new System.Exception(expectedErrorMessage);
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<System.Threading.CancellationToken>())).ThrowsAsync(exception);

        Assert.ThrowsAsync(Is.TypeOf<System.Exception>()
        .And.Message.Contains(expectedErrorMessage),
       async Task () => await _searchService!.GetAllBooks());
    }

}
