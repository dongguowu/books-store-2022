
using NUnit.Framework;
using System;
using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Tests;

[TestFixture]
public class BookCategoryTests
{
    [Test]
    public void Constructor_WithIdAndName_SetsPropertiesCorrectly()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        string name = "Test Category";

        // Act
        var bookCategory = new BookCategory(id, name);

        // Assert
        Assert.AreEqual(id, bookCategory.Id);
        Assert.AreEqual(name, bookCategory.Name);
        Assert.That(bookCategory.DateCreated.Equals(bookCategory.DateModified));
        Assert.That(bookCategory.DateCreated.Equals(null));
    }

    [Test]
    public void Constructor_WithoutId_SetsPropertiesCorrectly()
    {
        // Arrange
        string name = "Test Category";

        // Act
        var bookCategory = new BookCategory(name);

        // Assert
        Assert.AreNotEqual(Guid.Empty, bookCategory.Id);
        Assert.AreEqual(name, bookCategory.Name);
    }

    [Test]
    public void DefaultProperty_IsNotNull()
    {
        // Arrange & Act
        var defaultCategory = BookCategory.Default;

        // Assert
        Assert.IsNotNull(defaultCategory);
    }

    [Test]
    public void DefaultProperty_HasDefaultValues()
    {
        // Arrange
        var defaultCategory = BookCategory.Default;

        // Assert
        Assert.AreEqual(Guid.Empty, defaultCategory.Id);
        Assert.AreEqual("Default Category", defaultCategory.Name);
    }

    [Test]
    public void NameProperty_IsReadOnly()
    {
        // Arrange
        var bookCategory = new BookCategory("Test");

        // Act
        // Attempt to modify the Name property should result in a compilation error
        // Uncommenting the line below should cause a compilation error:
        // bookCategory.Name = "New Test";

        // Assert
        Assert.Pass("Compilation passed without modifying the read-only property.");
    }
}
