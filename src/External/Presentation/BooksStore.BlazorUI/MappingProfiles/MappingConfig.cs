using AutoMapper;
using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<BookCategoryDto, BookCategoryVm>().ReverseMap();
        CreateMap<BookCategoryDetailDto, BookCategoryVm>().ReverseMap();
        CreateMap<CreateBookCategoryCommand, BookCategoryVm>().ReverseMap();
        CreateMap<UpdateBookCategoryCommand, BookCategoryVm>().ReverseMap();
    }
}
