using AutoMapper;
using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.MappingProfiles;

public class BookCategoryProfile : Profile
{
    public BookCategoryProfile()
    {
        CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
        CreateMap<BookCategory, BookCategoryDetailDto>();
        CreateMap<BookCategoryDto, CreateBookCategoryCommand>();
        CreateMap<BookCategoryDto, UpdateBookCategoryCommand>();
        CreateMap<CreateBookCategoryCommand, BookCategory>();
        CreateMap<UpdateBookCategoryCommand, BookCategory>();
    }
}
