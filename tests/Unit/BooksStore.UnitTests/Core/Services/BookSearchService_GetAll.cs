using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.Services;
using Moq;
using NUnit.Framework;
using SharedKernel.Interfaces;

namespace BooksStore.UnitTests.Core.Services;

[TestFixture]
public class BookSearchService_GetAll
{
    [SetUp]
    public void Init()
    {
        _searchService = new BookSearchService(_mockRepo.Object);
    }

    private readonly Mock<IReadRepository<Book>> _mockRepo = new();
    private BookSearchService? _searchService;

    [TestCase]
    public async Task ReturnsList()
    {
        var title = "a test book";
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(
            new List<Book> { new(title, 23.31m), new(title, 23.31m) });

        var result = await _searchService!.GetAllBooks();

        Assert.That(result.Status, Is.EqualTo(ResultStatus.Ok));
        Assert.That(result.Value.Count, Is.EqualTo(2));
        Assert.That(result.Value[0].Title, Is.EqualTo(title));
        Assert.That(result.Value[1].Title, Is.EqualTo(title));
    }

    [TestCase]
    public void ReturnsError()
    {
        var expectedErrorMessage = "Database not there.";
        var exception = new Exception(expectedErrorMessage);
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<CancellationToken>())).ThrowsAsync(exception);

        Assert.ThrowsAsync(Is.TypeOf<Exception>()
                .And.Message.Contains(expectedErrorMessage),
            async Task () => await _searchService!.GetAllBooks());
    }
}
