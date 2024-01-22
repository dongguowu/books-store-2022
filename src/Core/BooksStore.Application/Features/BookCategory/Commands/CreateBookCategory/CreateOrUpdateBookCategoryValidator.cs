using AutoMapper;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;
using FluentValidation;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;

public class CreateOrUpdateBookCategoryValidator : AbstractValidator<CreateBookCategoryCommand>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;

    public CreateOrUpdateBookCategoryValidator(IReadRepository<Domain.Entities.BookCategory> rep, IMapper mapper)
    {
        _rep = rep;
        _mapper = mapper;

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
        return !await BookCategoryNameMustExist(command.Name, token);
    }

    private async Task<bool> BookCategoryNameMustExist(string name, CancellationToken token)
    {
        var query = new GetBookCategoryByNameQuery(name);
        var handler = new GetBookCategoryByNameQueryHandler(_rep, _mapper);
        var bookCategory = await handler.Handle(query, token);

        return bookCategory != null;
    }
}
