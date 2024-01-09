﻿using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using FluentValidation;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;

public class CreateBookCategoryValidator : AbstractValidator<CreateBookCategoryCommand>
{
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;

    public CreateBookCategoryValidator(IReadRepository<Domain.Entities.BookCategory> rep)
    {
        _rep = rep;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(q => q)
            .MustAsync(BookCategoryNameUnique)
            .WithMessage("Book category already exists.");
    }

    private async Task<bool> BookCategoryNameUnique(CreateBookCategoryCommand command, CancellationToken token)
    {
        var query = new GetBookCategoryByNameQuery(command.Name);
        var handler = new GetBookCategoryByNameQueryHandler(_rep);

        var bookCategory = await handler.Handle(query, token);

        return bookCategory != null;
    }
}