using SharedKernel;

namespace BooksStore.Domain.Entities;
public sealed class Book : BaseEntity
{
    public string Title { get; private set; } = "";
    public DateTime Created { get; private set; } = DateTime.Now;

    public Book() { }

    public Book(Guid id, string title, DateTime created) : base(id)
    {
        Title = title;
        Created = created;
    }
}
