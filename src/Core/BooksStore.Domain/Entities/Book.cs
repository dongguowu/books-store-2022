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

    public Book(string title, BookCategory category) : this(title)
    {
        Category = category;
    }

    public Book(string title, decimal price) : this(title)
    {
        Price = price;
    }

    public Book(string title, decimal price, BookCategory category) : this(title, price)
    {
        Category = category;
    }

    public Book(Guid id, string title, DateTime created) : base(id)
    {
        Title = title;
        Created = created;
    }

    public string Title { get; set; } = string.Empty;
    public DateTime Created { get; private set; } = DateTime.Now;
    public decimal Price { get; set; } = decimal.Zero;
    public BookCategory Category { get; set; } = BookCategory.Default;
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
