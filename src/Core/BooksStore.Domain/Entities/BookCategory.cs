using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace BooksStore.Domain.Entities;
public class BookCategory: BaseEntity
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
