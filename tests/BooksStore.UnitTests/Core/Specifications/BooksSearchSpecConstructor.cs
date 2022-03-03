using System;
using System.Collections.Generic;
using System.Linq;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.BookAggregate.Specifications;
using NUnit.Framework;

namespace BooksStore.UnitTests.Core.Specifications;

[TestFixture]
public class BooksSearchSpecConstructor
{
    [SetUp]
    public void Init()
    {

    }

    [TestCase()]
    public void ReturnBook()
    {
        String expectedString = Guid.NewGuid().ToString();

        var book1 = new Book(expectedString, 1.11m);
        var book2 = new Book("the second book", 2.11m)
        {
            Category = expectedString
        };
        var book3 = new Book("the third book", 3.11m);
        var books = new List<Book>() { book1, book2, book3 };

        var spec = new BooksSearchSpec(expectedString);

        var result = spec.Evaluate(books);
        if (result == null)
        {
            Assert.That(result, Is.Not.Null);
            return;
        }
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result, Does.Contain(book1));
        Assert.That(result, Does.Contain(book2));
        Assert.That(result, Does.Not.Contain(book3));
    }
}
