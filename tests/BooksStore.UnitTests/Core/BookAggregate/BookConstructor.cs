using System;
using BooksStore.Core.BookAggregate;
using NUnit.Framework;

namespace BooksStore.UnitTests.Core.BookAggregate;

[TestFixture]
public class BookConstructor
{
    private readonly string _testTitle = "test title";
    private readonly decimal _testPrice = 54.34m;
    private Book? _testBook;

    [SetUp]
    public void Init()
    {
        _testBook = CreateBook();
    }

    [TestCase()]
    public void InitializesTitle()
    {
        Assert.That(_testBook?.Title, Is.EqualTo(_testTitle));
    }
    [TestCase()]
    public void InitializesPrice()
    {
        Assert.That(_testBook?.Price, Is.EqualTo(_testPrice));
    }
    [TestCase()]
    public void InitializesId()
    {
        Console.WriteLine(_testBook.Id);

    }
    [TestCase()]
    public void InitializesCategoryToEmptyString()
    {
        Assert.That(_testBook?.Events, Is.Not.Null);
        Assert.That(_testBook?.Category, Is.EqualTo(string.Empty));
    }
    [TestCase()]
    public void InitializesImageUrlToEmptyString()
    {
        Assert.That(_testBook?.ImageUrl, Is.EqualTo(string.Empty));
    }
    [TestCase()]
    public void InitializesEventsToEmptyList()
    {
        Assert.That(_testBook?.Events, Is.Empty);
    }
    [TestCase()]
    public void InitializesToJSON()
    {
        Assert.That(_testBook?.ToJSON(), Does.Contain(_testTitle).IgnoreCase);
        Assert.That(_testBook?.ToJSON(), Does.Contain(_testPrice.ToString()).IgnoreCase);
        Assert.That(_testBook?.ToJSON(), Does.Contain(_testBook?.Id.ToString()).IgnoreCase);
    }
    [TestCase()]
    public void InitializesToString()
    {
        Assert.That(_testBook?.ToJSON(), Does.Contain(_testBook?.Id.ToString()).IgnoreCase);
    }

    [TestCase()]
    public void InitializesThrowArgumentException()
    {
        Assert.Throws(Is.TypeOf<ArgumentException>()
          .And.Message.Contains("Required input title was empty"),
          () => new Book("", _testPrice));
        Assert.Throws(Is.TypeOf<ArgumentException>()
          .And.Message.Contains("Required input price cannot be negative"),
          () => new Book(_testTitle, -1 * _testPrice));
    }


    private Book CreateBook()
    {
        return new Book(_testTitle, _testPrice);
    }

}
