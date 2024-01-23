using AutoMapper;
using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<DateTimeOffset, string>().ConvertUsing(dtOffset => dtOffset.ToString("yyyy-MM-dd / HH:mm:ss"));
        CreateMap<Guid, string>().ConvertUsing(guid => guid.ToString());
        CreateMap<BookCategoryDto, BookCategoryVm>().ReverseMap();
        CreateMap<BookCategoryDetailDto, BookCategoryDetailVm>().ReverseMap();
        CreateMap<BookCategoryDetailDto, BookCategoryVm>().ReverseMap();
        CreateMap<CreateBookCategoryCommand, BookCategoryVm>().ReverseMap();
        CreateMap<UpdateBookCategoryCommand, BookCategoryVm>().ReverseMap();
    }
}
