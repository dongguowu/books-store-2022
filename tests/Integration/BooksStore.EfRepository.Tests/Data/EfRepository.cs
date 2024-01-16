using System;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Domain.Entities;
using NUnit.Framework;
using SharedKernel.Interfaces;

namespace BooksStore.EfRepository.Tests.Data;

[TestFixture]
public class EfRepository : BaseEfRepTestFixture
{
    [SetUp]
    public void Init()
    {
        RefreshDatabase();
        _rep = GetRepository();
    }

    private IRepository<Book>? _rep;

    [TestCase]
    public async Task AddsBookAndSetsId()
    {
        var title = Guid.NewGuid().ToString();
        var price = 100.00m;
        var book = new Book(title, price);
        await _rep!.AddAsync(book);

        var result = (await _rep.ListAsync()).FirstOrDefault();

        if (result == null)
        {
            Assert.IsNotNull(result);
            return;
        }

        Assert.That(result.Title, Is.EqualTo(title));
        Assert.That(result.Price, Is.EqualTo(price));
    }

    [TestCase]
    public async Task DeletesBookAfterAddingIt()
    {
        // Add
        var title = Guid.NewGuid().ToString();
        var price = 100.00m;
        var book = new Book(title, price);
        await _rep!.AddAsync(book);

        // Delete
        await _rep.DeleteAsync(book);

        // Verify it's no longer there
        var result = await _rep.ListAsync();

        Assert.That(result, Is.Empty);
    }

    [TestCase]
    public async Task UpdatesBookAfterAddingIt()
    {
        // Setup
        var title = Guid.NewGuid().ToString();
        const decimal price = 100.00m;
        var category = new BookCategory(Guid.NewGuid().ToString());
        var book = new Book(title, price, category);


        // Add
        await _rep!.AddAsync(book);

        // Detach the book so we get a different instance
        // _dbContext.Entry(book).State = EntityState.Detached;

        // Fetch the book and update 
        var dbBook = (await _rep.ListAsync()).FirstOrDefault(b => b.Title == title);
        if (dbBook == null)
        {
            // Fail
            Assert.That(dbBook, Is.Not.Null);
            return;
        }

        var newTitle = "New Title";
        dbBook.Title = newTitle;

        var newBookCategory = new BookCategory(Guid.NewGuid().ToString());
        //dbBook.Category = newBookCategory;

        // Update the book
        await _rep.UpdateAsync(dbBook);

        // Fetch the updated book
        var updatedBook = (await _rep.ListAsync()).FirstOrDefault(b => b.Id == dbBook.Id);

        if (updatedBook == null)
        {
            // Fail
            Assert.That(updatedBook, Is.Not.Null);
            return;
        }

        Assert.That(updatedBook.Id, Is.EqualTo(dbBook.Id));
        Assert.That(updatedBook.Title, Is.EqualTo(newTitle));
        Assert.That(updatedBook.Price, Is.EqualTo(dbBook.Price));
        //Assert.That(updatedBook.Category, Is.Not.EqualTo(book.Category));
        //Assert.That(updatedBook.Category, Is.EqualTo(newBookCategory));
    }
}
