
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
