using System.Reflection;
using BooksStore.Application.Features.Books.Commands.CreateBook;
using BooksStore.Debug.Console;
using BooksStore.Domain.Entities;
using BooksStore.Infrastructure;
using NetArchTest.Rules;

namespace BooksStore.Architecture.Tests;

[TestFixture]
public class ArchitectureTests
{
    private const string SharedKernelNamespace = "SharedKernel";
    private const string DomainNamespace = "BooksStore.Domain";
    private const string ApplicationNamespace = "BooksStore.Application";

    private readonly string[] InfrastructureNamespaces =
    {
        "BooksStore.Infrastructure", "BooksStore.Infrastructure.Shared"
    };

    private readonly string[] PresentationNamespaces = { "BooksStore.Presentation" };

    [TestCase]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Book).Assembly;
        var otherProjects = new[] { ApplicationNamespace }.Concat(InfrastructureNamespaces)
            .Concat(PresentationNamespaces).ToArray();

        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Domain_Should_Have_DependencyOnSharedKernel()
    {
        // Arrange
        var domainAssembly = GetAssemblyByNamespace(DomainNamespace);
        if (domainAssembly == null)
        {
            Assert.Fail($"Assembly for namespace '{DomainNamespace}' not found.");
        }

        var dependency = SharedKernelNamespace;

        // Act
        var testResult = Types.InAssembly(domainAssembly).That().HaveNameEndingWith("Book").Should()
            .HaveDependencyOn(dependency).GetResult();

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
        var otherProjects = InfrastructureNamespaces.Concat(PresentationNamespaces).ToArray();
        // Act
        var testResult = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAll(otherProjects).GetResult();

        // Assert
        Assert.That(testResult.IsSuccessful, Is.True);
    }

    [TestCase]
    public void Application_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var assembly = typeof(CreateBookCommandHandler).Assembly;
        var otherProject = DomainNamespace;

        // Act
        var testResult = Types.InAssembly(assembly).That().HaveNameEndingWith("CreateBookCommandHandler").Should()
            .HaveDependencyOn(otherProject).GetResult();

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
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        // var assembly = typeof(BooksStore.Application.AssemblyReference).Assembly;
        var assembly = typeof(Class1).Assembly;

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

    // Method to retrieve assembly by namespace
    private Assembly? GetAssemblyByNamespace(string namespaceToSearch)
    {
        try
        {
            return Assembly.Load(namespaceToSearch);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading assembly: {ex.Message}");
            return null;
        }
        //return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(assembly => assembly.GetTypes().Any(type => type.Namespace == namespaceToSearch));
    }
}
