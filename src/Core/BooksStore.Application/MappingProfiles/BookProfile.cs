using AutoMapper;
using BooksStore.Application.Features.Books.Queries.GetBookDetail;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookDetailDto, Book>().ReverseMap();
    }
}
