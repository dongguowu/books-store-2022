using AutoMapper;
using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<BookCategoryDto, BookCategoryVM>().ReverseMap();
        CreateMap<CreateBookCategoryCommand, BookCategoryVM>().ReverseMap();
        CreateMap<UpdateBookCategoryCommand, BookCategoryVM>().ReverseMap();
    }
}
