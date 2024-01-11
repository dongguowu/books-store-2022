using System.Collections.Generic;
using System.Linq;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using BooksStore.Domain.Entities;
using NUnit.Framework;

namespace BooksStore.UnitTests.Core.Specifications;

[TestFixture]
internal class GetBookCategoryByIdSpecConstructor
{
    [SetUp]
    public void Init()
    {
    }

    [TestCase]
    public void ReturnBookCategory()
    {
        const string name = "test category";
        var category01 = new BookCategory(name);
        var category02 = new BookCategory("2");
        var category03 = new BookCategory("3");
        var list = new List<BookCategory> { category01, category02, category03 };

        var spec = new BookCategoryByNameSpec(name);

        var result = spec.Evaluate(list);
        var enumerable = result as BookCategory[] ?? result.ToArray();
        Assert.That(enumerable, Does.Contain(category01));
        Assert.That(enumerable, Does.Not.Contain(category02));
        Assert.That(enumerable, Does.Not.Contain(category03));
    }
}
