using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.Contracts;

public interface IBookCategoryService
{
    Task<List<BookCategoryDto>> GetBookCategories();
    Task<BookCategoryVM> GetBookCategory(Guid id);

    Task<Response<Guid>> CreateBookCategory(BookCategoryVM bookCategory);
    Task<Response<Guid>> DeleteBookCategory(Guid id);
}
