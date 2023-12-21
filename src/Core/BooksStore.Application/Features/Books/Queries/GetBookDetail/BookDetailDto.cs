namespace BooksStore.Application.Features.Books.Queries.GetBookDetail;

public class BookDetailDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime Created { get; private set; } = DateTime.Now;
    public decimal Price { get; private set; } = decimal.Zero;
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
