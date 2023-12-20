using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;

namespace BooksStore.Domain.Entities;
public class BookCategory: BaseEntity
{
    public string Name { get; set; }

    public BookCategory()
    {
        Id = Guid.Empty;
        Name = "No Category";
    }


    private static BookCategory? _defaultCategory;

    public static BookCategory DefaultBookCategory()
    {
        _defaultCategory ??= new BookCategory();
        return _defaultCategory;
    }

}
