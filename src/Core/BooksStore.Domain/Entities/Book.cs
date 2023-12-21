using Newtonsoft.Json;
using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Domain.Entities;

public sealed class Book : BaseEntity, IAggregateRoot
{
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

    public string Title { get; private set; }
    public DateTime Created { get; private set; } = DateTime.Now;
    public decimal Price { get; private set; } = decimal.Zero;
    public BookCategory Category { get; set; } = BookCategory.DefaultBookCategory;
    public string ImageUrl { get; set; } = string.Empty;

    public string ToJSON()
    {
        return JsonConvert.SerializeObject(this, (Formatting)System.Xml.Formatting.Indented);
    }

    public override string ToString()
    {
        return ToJSON();
    }
}
