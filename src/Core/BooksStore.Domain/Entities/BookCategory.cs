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

    public string Name { get; set; }

    public static BookCategory Default { get; } = new(Guid.Empty, "Default Category");
}
