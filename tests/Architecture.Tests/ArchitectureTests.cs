using NetArchTest.Rules;

namespace BooksStore.Architecture.Tests;

[TestFixture]
public class ArchitectureTests
{
    private const string DomainNamespace = "BooksStore.Domain";
    private const string ApplicationNamespace = "BooksStore.Application";
    private const string InfrastructureNamespace = "BooksStore.Infrastructure";
    private const string PresentationNamespace = "BooksStore.Presentation";
    private const string WebNamespace = "BooksStore.Web";

    [TestCase()]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(BooksStore.Domain.Class1).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace, InfrastructureNamespace, PresentationNamespace, WebNamespace,
        };

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }


    [TestCase()]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(BooksStore.Application.Books.Commands.CreateBookCommand).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace, PresentationNamespace, WebNamespace,
        };

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase()]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(BooksStore.Infrastructure.ApplicationDbContext).Assembly;

        var otherProjects = new[]
        {
            PresentationNamespace, WebNamespace,
        };

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase()]
    public void Presentation_should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(BooksStore.Infrastructure.ApplicationDbContext).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace, WebNamespace,
        };

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase()]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var assembly = typeof(BooksStore.Application.Books.Commands.CreateBookCommandHandler).Assembly;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Handler").Should().HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase()]
    public void ValidationBehavior_Should_Have_DependencyOnMediatR()
    {
        // Arrange
        var assembly = typeof(BooksStore.Application.Books.Commands.CreateBookCommandHandler).Assembly;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Behavior").Should().HaveDependencyOn("MediatR").GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);

    }
}
