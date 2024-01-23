using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.Contracts;

public interface IBookCategoryService
{
    Task<List<BookCategoryVm>> GetBookCategories(string? queryString);
    Task<BookCategoryDetailVm> GetBookCategory(Guid id);
    Task<BookCategoryVm> GetBookCategoryWithoutDetail(Guid id);

    Task<Response<Guid>> CreateBookCategory(BookCategoryVm bookCategory);
    Task<Response<Guid>> UpdateBookCategory(BookCategoryVm bookCategory);
    Task<Response<Guid>> DeleteBookCategory(Guid id);
}
