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

public class GetAllBookCategoriesHandlerTests
{
    private readonly Mock<IAppLogger<GetAllBookCategoriesQueryHandler>> _appLogger;
    private readonly IMapper _mapper;
    private readonly Mock<IReadRepository<BookCategory>> _mockReadRepo;


    public GetAllBookCategoriesHandlerTests()
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

        var results = await handler.Handle(new GetAllBookCategoriesQuery(), CancellationToken.None);

        results.ShouldNotBeNull();
        results.ShouldBeOfType<List<BookCategoryDto>>();
        results.Count.ShouldBe(MockBookCategoryRepository._list.Count);


        var result = results.FirstOrDefault();
        result.ShouldNotBeNull();
        result.Id.ShouldBeOfType<Guid>();
        result.Id.ShouldNotBe(Guid.Empty);


        result.Name.ShouldNotBeNull();
        result.Name.ShouldBeOfType<string>();
        result.Name.ShouldNotBe(string.Empty);
    }
}
