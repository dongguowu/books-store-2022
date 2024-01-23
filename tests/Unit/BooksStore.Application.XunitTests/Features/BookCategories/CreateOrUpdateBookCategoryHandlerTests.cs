using AutoMapper;
using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using BooksStore.Application.Interfaces.Shared;
using BooksStore.Application.MappingProfiles;
using BooksStore.Application.XunitTests.Mocks;
using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Exceptions;
using SharedKernel.Interfaces;
using Shouldly;

namespace BooksStore.Application.XunitTests.Features.BookCategories;

public class CreateOrUpdateBookCategoryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<UpdateBookCategoryCommandHandler>> _mockAppLogger;
    private readonly Mock<IReadRepository<BookCategory>> _mockReadRep;
    private readonly Mock<IRepository<BookCategory>> _mockWriteRep;

    public CreateOrUpdateBookCategoryHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<BookCategoryProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _mockReadRep = MockBookCategoryRepository.GetReadRepositoryWithDefaultList();
        _mockWriteRep = MockBookCategoryRepository.GetWriteRepositoryWithDefaultList();
        _mockAppLogger = new Mock<IAppLogger<UpdateBookCategoryCommandHandler>>();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddToCategoriesRepo()
    {
        var originalCount = (await _mockReadRep.Object.ListAsync(CancellationToken.None))?.Count ?? 0;

        // Setup the GetBySpecAsync method 
        var cancellationToken = It.IsAny<CancellationToken>();
        _mockReadRep
            .Setup(r => r.GetBySpecAsync(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync((BookCategory?)null);

        // Create new Book Category
        var handler = new CreateBookCategoryCommandHandler(_mockReadRep.Object, _mockWriteRep.Object, _mapper);
        var categoryToCreate = new BookCategoryDto { Name = "Test Category" };
        await handler.Handle(_mapper.Map<CreateBookCategoryCommand>(categoryToCreate), CancellationToken.None);

        // Setup the GetBySpecAsync method 
        _mockReadRep
            .Setup(r => r.GetBySpecAsync(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync(BookCategory.Default);

        var currentCount = (await _mockReadRep.Object.ListAsync(CancellationToken.None))?.Count ?? 0;
        currentCount.ShouldBe(originalCount + 1);
    }

    [Fact]
    public async Task Handle_InvalidCategory_AddToCategoriesRepo_Throw_BadRequestException()
    {
        // Setup the GetBySpecAsync method 
        var cancellationToken = It.IsAny<CancellationToken>();
        _mockReadRep
            .Setup(r => r.GetBySpecAsync(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync(BookCategory.Default);

        // Create new Book Category
        var handler = new CreateBookCategoryCommandHandler(_mockReadRep.Object, _mockWriteRep.Object, _mapper);

        // Act and Assert
        await Assert.ThrowsAsync<BadRequestException>(
            async () => await handler.Handle(new CreateBookCategoryCommand("Test Category"), CancellationToken.None)
        );
    }

    [Fact]
    public async Task Handle_ValidCategory_UpdateCategoriesRepo()
    {
        // Setup the GetBySpecAsync method 
        var cancellationToken = It.IsAny<CancellationToken>();
        _mockReadRep
            .Setup(r => r.GetBySpecAsync(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync((BookCategory?)null);

        _mockWriteRep
            .Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), cancellationToken)).ReturnsAsync(BookCategory.Default);

        _mockWriteRep
            .Setup(r => r.UpdateAsync(It.IsAny<BookCategory>(), cancellationToken)).Returns(Task.CompletedTask);

        // Create new Book Category
        var handler = new UpdateBookCategoryCommandHandler(_mockReadRep.Object, _mockWriteRep.Object, _mapper,
            _mockAppLogger.Object);
        var result = await handler.Handle(new UpdateBookCategoryCommand(Guid.NewGuid(), "Test Category"),
            CancellationToken.None);

        result.ShouldBe(true);
    }

    [Fact]
    public async Task Handle_InvalidCategory_UpdateCategoriesRepo_Throw_BadRequestException()
    {
        var cancellationToken = It.IsAny<CancellationToken>();
        // Setup method 
        _mockReadRep
            .Setup(r => r.GetBySpecAsync(
                It.IsAny<BookCategoryByNameSpec>(),
                cancellationToken
            ))
            .ReturnsAsync(BookCategory.Default);

        // Create new Book Category
        var handler = new UpdateBookCategoryCommandHandler(_mockReadRep.Object, _mockWriteRep.Object, _mapper,
            _mockAppLogger.Object);

        // Act and Assert
        await Assert.ThrowsAsync<BadRequestException>(
            async () => await handler.Handle(new UpdateBookCategoryCommand(Guid.NewGuid(), "Test Category"),
                CancellationToken.None)
        );
    }
}
