using AutoMapper;
using BooksStore.BlazorUI.Contracts;
using BooksStore.BlazorUI.Services.Base;
using BooksStore.BlazorUI.ViewModels;

namespace BooksStore.BlazorUI.Services;

public class BookCategoryService : BaseHttpService, IBookCategoryService
{
    private readonly IMapper _mapper;

    public BookCategoryService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<List<BookCategoryVm>> GetBookCategories()
    {
        var results = await _client.BookCategoriesAllAsync();
        return _mapper.Map<List<BookCategoryVm>>(results);
    }

    public async Task<BookCategoryDetailVm> GetBookCategory(Guid id)
    {
        var result = await _client.BookCategoriesGETAsync(id);
        return _mapper.Map<BookCategoryDetailVm>(result);
    }

    public async Task<BookCategoryVm> GetBookCategoryWithoutDetail(Guid id)
    {
        var result = await _client.BookCategoriesGETAsync(id);
        return _mapper.Map<BookCategoryVm>(result);
    }

    public async Task<Response<Guid>> CreateBookCategory(BookCategoryVm bookCategory)
    {
        try
        {
            var command = _mapper.Map<CreateBookCategoryCommand>(bookCategory);
            await _client.BookCategoriesPOSTAsync(command, CancellationToken.None);
            return new Response<Guid> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateBookCategory(BookCategoryVm bookCategory)
    {
        try
        {
            var command = _mapper.Map<UpdateBookCategoryCommand>(bookCategory);
            var id = Guid.Parse(bookCategory.Id);
            await _client.BookCategoriesPUTAsync(id, command, CancellationToken.None);
            return new Response<Guid> { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteBookCategory(Guid id)
    {
        try
        {
            await _client.BookCategoriesDELETEAsync(id);
            return new Response<Guid> { Success = true };
        }
        catch (ApiException e)
        {
            return ConvertApiExceptions<Guid>(e);
        }
    }
}
