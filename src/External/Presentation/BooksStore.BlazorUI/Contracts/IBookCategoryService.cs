using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.Contracts;

public interface IBookCategoryService
{
    Task<List<BookCategoryVm>> GetBookCategories();
    Task<BookCategoryVm> GetBookCategory(Guid id);

    Task<Response<Guid>> CreateBookCategory(BookCategoryVm bookCategory);
    Task<Response<Guid>> DeleteBookCategory(Guid id);
}
