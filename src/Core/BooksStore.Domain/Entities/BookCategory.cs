using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Domain.Entities;
public class BookCategory: BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }

    public BookCategory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public BookCategory(string name) : this(Guid.NewGuid(), name) { }

    private BookCategory() : this(Guid.Empty, "No Category") { }

    public static BookCategory DefaultBookCategory { get; } = new BookCategory();
}
