using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Domain.Entities;

public class BookCategory : BaseEntity, IAggregateRoot
{
    public BookCategory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public BookCategory(string name) : this(Guid.NewGuid(), name) { }

    private BookCategory() : this(Guid.Empty,string.Empty) { }
    public string Name { get; set; }

    public static BookCategory Default { get; } = new();
}
