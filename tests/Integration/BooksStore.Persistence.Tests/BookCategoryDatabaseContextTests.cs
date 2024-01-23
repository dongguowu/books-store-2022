using BooksStore.Domain.Entities;
using BooksStore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Persistence.Tests;

public class BookCategoryDatabaseContextTests
{
    private readonly List<BookCategory> _list = [];
    private BookDatabaseContext _context;

    [SetUp]
    public void Setup()
    {
        var dbContextOptions = new DbContextOptionsBuilder<BookDatabaseContext>()
            .UseInMemoryDatabase("TestDatabase-" + Guid.NewGuid()) // Unique database name for each test
            .Options;

        _context = new BookDatabaseContext(dbContextOptions);

        _list.Add(new BookCategory("category_01"));
        _list.Add(new BookCategory("category_02"));
        _list.Add(new BookCategory("category_03"));
        _list.Add(new BookCategory("category_04"));
    }

    [TearDown]
    public void Cleanup()
    {
        _context?.Database.EnsureDeleted(); // Remove the database after each test
        _context = null!;
    }

    [TestCase]
    public async Task Save_List()
    {
        // Arrange & Act
        if (_context.BookCategories == null)
        {
            Assert.Fail();
        }
        await _context!.BookCategories!.AddRangeAsync(_list);
        await _context.SaveChangesAsync();

        foreach (var category in _list)
        {
            Assert.That(category.Id, Is.TypeOf<Guid>());
            Assert.That(category.Name, Is.Not.Empty);
            Assert.That(category.DateCreated, Is.Not.Null);
            Assert.That(category.DateCreated, Is.TypeOf<DateTime>());
            Assert.That(category.DateModified, Is.Not.Null);
        }
    }
}
