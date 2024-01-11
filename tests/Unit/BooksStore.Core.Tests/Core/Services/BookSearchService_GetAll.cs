using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using BooksStore.Application.Features.Books.Queries.SearchBooks;
using BooksStore.Application.Services;
using BooksStore.Domain.Entities;
using Moq;
using NUnit.Framework;
using SharedKernel.Interfaces;

namespace BooksStore.UnitTests.Core.Services;

[TestFixture]
public class BookSearchServiceGetAll
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
        const string title = "a test book";
        var list = new List<Book> { new(title), new(title + "02") };
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<BooksSearchSpec>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(list);

        var result = await _searchService!.GetAllBooks();

        Assert.That(result.Status, Is.EqualTo(ResultStatus.Ok));
        Assert.That(result.Value.Count, Is.EqualTo(2));
        Assert.That(result.Value[0].Title, Is.EqualTo(title));
        Assert.That(result.Value[1].Title, Is.Not.EqualTo(title));
    }

    [TestCase]
    public void ReturnsError()
    {
        var expectedErrorMessage = "Database not there.";
        var exception = new Exception(expectedErrorMessage);
        _mockRepo.Setup(r => r.ListAsync(It.IsAny<BooksSearchSpec>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(exception);

        Assert.ThrowsAsync(Is.TypeOf<Exception>()
                .And.Message.Contains(expectedErrorMessage),
            async Task () => await _searchService!.GetAllBooks());
    }
}
