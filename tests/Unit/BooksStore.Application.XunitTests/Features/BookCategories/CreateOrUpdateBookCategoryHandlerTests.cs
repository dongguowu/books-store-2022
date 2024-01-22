using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using BooksStore.Application.Features.Books.Commands.CreateBook;
using BooksStore.Application.MappingProfiles;
using BooksStore.Application.XunitTests.Mocks;
using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Interfaces;
using Shouldly;

namespace BooksStore.Application.XunitTests.Features.BookCategories;
public class CreateOrUpdateBookCategoryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IReadRepository<BookCategory>> _mockReadRep;
    private readonly Mock<IRepository<BookCategory>> _mockRep;

    public CreateOrUpdateBookCategoryHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<BookCategoryProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockReadRep = MockBookCategoryRepository.GetReadRepository();
        _mockRep = MockBookCategoryRepository.GetWriteRepository();
    }

    [Fact]
    public async Task Handle_validCategory_AddToCategoriesRepo()
    {
        var originalCount = (await _mockReadRep.Object.ListAsync(CancellationToken.None))?.Count ?? 0;
        var handler = new CreateBookCategoryCommandHandler(_mockReadRep.Object, _mockRep.Object, _mapper);


        // Setup the GetBySpecAsync method with the specification
        var cancellationToken = It.IsAny<CancellationToken>();
        _mockReadRep
            .Setup(r => r.GetBySpecAsync<BookCategoryByNameSpec>(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync((BookCategory?)null);

        await handler.Handle(new CreateBookCategoryCommand("Test Category"), CancellationToken.None);

        _mockReadRep
            .Setup(r => r.GetBySpecAsync<BookCategoryByNameSpec>(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync(BookCategory.Default);

        var currentCount = (await _mockReadRep.Object.ListAsync(CancellationToken.None))?.Count ?? 0;

        currentCount.ShouldBe(originalCount + 1);
    }
}
