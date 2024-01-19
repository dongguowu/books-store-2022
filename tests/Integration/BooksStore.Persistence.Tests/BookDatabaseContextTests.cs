using BooksStore.Domain.Entities;
using BooksStore.Persistence.DatabaseContext;
using BooksStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Persistence.Tests;

[TestFixture]
public class BookDatabaseContextTests
{
    [SetUp]
    public void Setup()
    {
        var dbContextOptions = new DbContextOptionsBuilder<BookDatabaseContext>()
            .UseInMemoryDatabase("TestDatabase-" + Guid.NewGuid()) // Unique database name for each test
            .Options;

        _context = new BookDatabaseContext(dbContextOptions);
    }

    [TearDown]
    public void Cleanup()
    {
        _context?.Database.EnsureDeleted(); // Remove the database after each test
        _context = null;
    }

    private BookDatabaseContext? _context;


    [TestCase]
    public async Task AddBookAndSetId()
    {
        var title = Guid.NewGuid().ToString();
        var price = 100.00m;
        var book = new Book(title, price, BookCategory.Default);
        var rep = new EfRepository<Book>(_context);
        await rep!.AddAsync(book);

        var result = (await rep.ListAsync()).FirstOrDefault();

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
        var book = new Book(title, price, BookCategory.Default);
        var _rep = new EfRepository<Book>(_context);
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

        var _rep = new EfRepository<Book>(_context);

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
