﻿using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.MappingProfiles;

public class BookCategoryProfile : Profile
{
    public BookCategoryProfile()
    {
        CreateMap<BookCategoryDto, BookCategory>().ReverseMap();
    }
}
