using System.Collections.Generic;
using System.Linq;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.BookAggregate.Specifications;
using NUnit.Framework;

namespace BooksStore.UnitTests.Core.Specifications;

[TestFixture]
internal class BookByIdSpecConstructor
{
    [SetUp]
    public void Init()
    {

    }

    [TestCase()]
    public void ReturnBook()
    {
        var book1 = new Book("the first book", 1.11m);
        var id = book1.Id;
        var book2 = new Book("the second book", 2.11m);
        var book3 = new Book("the third book", 3.11m);
        var books = new List<Book>() { book1, book2, book3 };

        var spec = new BookByIdSpec(id);

        var result = spec.Evaluate(books);
        var enumerable = result as Book[] ?? result.ToArray();
        Assert.That(enumerable, Does.Contain(book1));
        Assert.That(enumerable, Does.Not.Contain(book2));
        Assert.That(enumerable, Does.Not.Contain(book3));
    }
}
