using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Application.Interfaces.Shared;
using BooksStore.Application.MappingProfiles;
using BooksStore.Application.XunitTests.Mocks;
using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Interfaces;
using Shouldly;

namespace BooksStore.Application.XunitTests.Features.BookCategories;

public class GetBookCategoriesHandlerTests
{
    private readonly Mock<IAppLogger<GetAllBookCategoriesQueryHandler>> _appLogger;
    private readonly IMapper _mapper;
    private readonly Mock<IReadRepository<BookCategory>> _mockReadRepo;


    public GetBookCategoriesHandlerTests()
    {
        _mockReadRepo = MockBookCategoryRepository.GetReadRepositoryWithDefaultList();
        var mapperConifg = new MapperConfiguration(c =>
        {
            c.AddProfile<BookCategoryProfile>();
        });

        _mapper = mapperConifg.CreateMapper();
        _appLogger = new Mock<IAppLogger<GetAllBookCategoriesQueryHandler>>();
    }

    [Fact]
    public async Task GetAllBookCategoriesListTest()
    {
        var handler = new GetAllBookCategoriesQueryHandler(_mockReadRepo.Object, _mapper, _appLogger.Object);

        var result = await handler.Handle(new GetAllBookCategoriesQuery(), CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<BookCategoryDto>>();
        result.Count.ShouldBe(MockBookCategoryRepository._list.Count);
    }
}
