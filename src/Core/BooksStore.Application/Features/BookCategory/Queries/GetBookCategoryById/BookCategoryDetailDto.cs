namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;

public class BookCategoryDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
