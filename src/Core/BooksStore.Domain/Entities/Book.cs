using Newtonsoft.Json;
using SharedKernel;
using Formatting = System.Xml.Formatting;

namespace BooksStore.Domain.Entities;
public sealed class Book : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public DateTime Created { get; private set; } = DateTime.Now;
    public decimal Price { get; private set; } = decimal.Zero;
    public BookCategory Category { get; set; } = BookCategory.DefaultBookCategory;
    public string ImageUrl { get; set; } = string.Empty;

    public Book(string title)
    {
        Title = title;
    }

    public Book(string title, BookCategory category)
    {
        Title = title;
        Category = category;
    }

    public Book(Guid id, string title, DateTime created) : base(id)
    {
        Title = title;
        Created = created;
    }

    public Book(string title, decimal price)
    {
        Title = title;
        Price = price;
    }

    public string ToJSON() => JsonConvert.SerializeObject(this, (Newtonsoft.Json.Formatting)Formatting.Indented);
    public override string ToString()
    {
        return ToJSON();
    }
}
