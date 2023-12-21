using Ardalis.GuardClauses;
using Newtonsoft.Json;
using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Core.BookAggregate;

public class Book : BaseEntity, IAggregateRoot
{
    public Book(string title, decimal price)
    {
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        Price = Guard.Against.Negative(price, nameof(price));
    }

    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public string ToJSON()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return ToJSON();
    }
}
