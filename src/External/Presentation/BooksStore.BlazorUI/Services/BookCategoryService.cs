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

    public async Task<List<BookCategoryVM>> GetBookCategories()
    {
        var results = await _client.BookCategoryAllAsync();
        return _mapper.Map<List<BookCategoryVM>>(results);

    }

    public Task<BookCategoryVM> GetBookCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> CreateBookCategory(BookCategoryVM bookCategory)
    {
        try
        {
            var command = _mapper.Map<CreateBookCategoryCommand>(bookCategory);
            await _client.BookCategoryPOSTAsync(command, CancellationToken.None);
            return new Response<Guid>() { Success = true, };
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
            await _client.BookCategoryDELETEAsync(id);
            return new Response<Guid>() { Success = true, };

        }
        catch (ApiException e)
        {
            return ConvertApiExceptions<Guid>(e);
        }
    }
}
