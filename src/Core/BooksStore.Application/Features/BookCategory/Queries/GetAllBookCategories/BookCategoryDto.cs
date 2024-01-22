namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public class BookCategoryDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
}
