using System;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Domain.Entities;
using BooksStore.Infra.Data.Context;
using BooksStore.Infra.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SharedKernel.Interfaces;

namespace BooksStore.IntegrationTests.Data;

[TestFixture]
public class SqliteEfRepository
{
    [SetUp]
    public void Init()
    {
        //var folder = Environment.SpecialFolder.LocalApplicationData;
        //var path = Environment.GetFolderPath(folder);
        //var dbPath = System.IO.Path.Join(path, "booksStore.db");
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=books_test.db");
        _dbContext = new AppDbContext(optionsBuilder.Options, new Mock<IMediator>().Object);
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
        _rep = new EfRepository<Book>(_dbContext);
    }

    private IRepository<Book>? _rep;
    private AppDbContext? _dbContext;

    [TestCase]
    public async Task AddsBookAndSetsId()
    {
        var title = Guid.NewGuid().ToString();
        var price = 100.00m;
        var book = new Book(title, price);
        await _rep!.AddAsync(book);
        await _rep!.SaveChangesAsync();

        var result = (await _rep.ListAsync()).FirstOrDefault();

        if (result == null)
        {
            Assert.IsNotNull(result);
            return;
        }

        Assert.That(result.Title, Is.EqualTo(title));
        Assert.That(result.Price, Is.EqualTo(price));
        //Assert.That(result.Id.Trim().Length, Is.GreaterThan(20));
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
        // Add
        var title = Guid.NewGuid().ToString();
        var category = new BookCategory(Guid.NewGuid().ToString());
        var price = 100.00m;
        var book = new Book(title, price);
        book.Category = category;
        await _rep!.AddAsync(book);

        // Detach the book so we get a different instance
        _dbContext!.Entry(book).State = EntityState.Detached;

        // Fetch the book and update its category
        var dbBook = (await _rep.ListAsync()).FirstOrDefault(b => b.Title == title);
        if (dbBook == null)
        {
            Assert.That(dbBook, Is.Not.Null);
            return;
        }

        Assert.AreNotSame(book, dbBook);
        var toUpdateCategory = new BookCategory(Guid.NewGuid().ToString());
        dbBook.Category = toUpdateCategory;

        // Update the book
        await _rep.UpdateAsync(dbBook);

        // Fetch the updated book
        var updatedBook = (await _rep.ListAsync()).FirstOrDefault(b => b.Title == title);

        if (updatedBook == null)
        {
            Assert.That(updatedBook, Is.Not.Null);
            return;
        }

        Assert.That(updatedBook.Id, Is.EqualTo(dbBook.Id));
        Assert.That(updatedBook.Title, Is.EqualTo(dbBook.Title));
        Assert.That(updatedBook.Price, Is.EqualTo(dbBook.Price));
        Assert.That(updatedBook.Category, Is.Not.EqualTo(book.Category));
        Assert.That(updatedBook.Category, Is.EqualTo(dbBook.Category));
        Assert.That(updatedBook.Category, Is.EqualTo(toUpdateCategory));
    }
}
