using System.Security.Cryptography.X509Certificates;
using BooksStore.Application.Books.Commands;
using BooksStore.Domain.Entities;
using BooksStore.Infrastructure;
using NetArchTest.Rules;

namespace BooksStore.Architecture.Tests;

[TestFixture]
public class ArchitectureTests
{
    private const string DomainNamespace = "BooksStore.Domain";
    private const string ApplicationNamespace = "BooksStore.Application";

    private readonly string[] InfrastructureNamespaces = new[] { "BooksStore.Infrastructure" };
    private readonly string[] PresentationNamespaces = new[] { "BooksStore.Presentation" };

    [TestCase]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Book).Assembly;

        var otherProjects = new[] { ApplicationNamespace }.Concat(InfrastructureNamespaces).Concat(PresentationNamespaces).ToArray() as string[];

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Domain_Should_Have_DependencyOnSharedKernel()
    {
        // Arrange
        var assembly = typeof(Book).Assembly;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Book").Should()
            .HaveDependencyOn("SharedKernel").GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(CreateBookCommand).Assembly;

        //var otherProjects = new[] { InfrastructureNamespaces, PresentationNamespaces, WebNamespace };
        var otherProjects = InfrastructureNamespaces.Concat(PresentationNamespaces).ToArray() as string[];
        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }


    [TestCase]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(ApplicationDbContext).Assembly;

        //var otherProjects = new[] { PresentationNamespaces, WebNamespace };
        var otherProjects = PresentationNamespaces;
        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Presentation_should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(BooksStore.Debug.Console.Class1).Assembly;

        //var otherProjects = new[] { InfrastructureNamespaces, WebNamespace };
        var otherProjects = InfrastructureNamespaces;

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var assembly = typeof(CreateBookCommandHandler).Assembly;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Handler").Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void ValidationBehavior_Should_Have_DependencyOnMediatR()
    {
        // Arrange
        var assembly = typeof(CreateBookCommandHandler).Assembly;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("Behavior").Should()
            .HaveDependencyOn("MediatR").GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }
}
