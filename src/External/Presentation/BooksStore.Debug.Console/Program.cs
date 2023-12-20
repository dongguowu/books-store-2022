
using BooksStore.Domain.Entities;

var str = "debug....";
var book = new Book(str);
Console.WriteLine(str);
Console.WriteLine(book);
Console.WriteLine(book.Category.GetHashCode());


 str = "second....";
 book = new Book(str);
Console.WriteLine(str);
Console.WriteLine(book);
Console.WriteLine(book.Category.GetHashCode());

var category = new BookCategory("type one");
book = new Book(str, category);
Console.WriteLine(book);
Console.WriteLine(book.Category.GetHashCode());
