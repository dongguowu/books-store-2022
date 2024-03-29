﻿using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using BooksStore.Application.MappingProfiles;
using BooksStore.Application.XunitTests.Mocks;
using BooksStore.Domain.Entities;
using Moq;
using SharedKernel.Interfaces;
using Shouldly;

namespace BooksStore.Application.XunitTests.Features.BookCategories;

public class GetBookCategoryByNameHanlderTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IReadRepository<BookCategory>> _mockReadRepo;


    public GetBookCategoryByNameHanlderTests()
    {
        _mockReadRepo = MockBookCategoryRepository.GetReadRepositoryWithDefaultList();
        var mapperConifg = new MapperConfiguration(c =>
        {
            c.AddProfile<BookCategoryProfile>();
        });

        _mapper = mapperConifg.CreateMapper();
    }

    [Fact]
    public async Task GetBookCategoryTest()
    {
        var bookcategory = BookCategory.Default;
        _mockReadRepo.Setup(r => r.GetBySpecAsync(It.IsAny<BookCategoryByNameSpec>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(bookcategory);
        var handler = new GetBookCategoryByNameQueryHandler(_mockReadRepo.Object, _mapper);

        var result = await handler.Handle(new GetBookCategoryByNameQuery("any validate name"), CancellationToken.None);

        result.ShouldNotBeNull();
        result.ShouldBeOfType<BookCategoryDetailDto>();
        result.Id.ShouldBeOfType<Guid>();
        result.Id.ShouldBe(Guid.Empty);
        result.Name.ShouldContain("Default");
    }
}
