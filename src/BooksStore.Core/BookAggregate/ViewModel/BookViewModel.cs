using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Core.BookAggregate.ViewModel;
public class BookViewModel
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
