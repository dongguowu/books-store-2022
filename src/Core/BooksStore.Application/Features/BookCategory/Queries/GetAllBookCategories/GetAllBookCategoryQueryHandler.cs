﻿using AutoMapper;
using BooksStore.Application.Interfaces.Shared;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public class GetAllBookCategoryQueryHandler : IRequestHandler<GetAllBookCategoryQuery, List<BookCategoryDto>>
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<Domain.Entities.BookCategory> _rep;
    private readonly IAppLogger<GetAllBookCategoryQueryHandler> _logger;

    public GetAllBookCategoryQueryHandler(IReadRepository<Domain.Entities.BookCategory> rep, IMapper mapper, IAppLogger<GetAllBookCategoryQueryHandler> logger)
    {
        _mapper = mapper;
        _rep = rep;
        _logger = logger;
    }

    public async Task<List<BookCategoryDto>> Handle(GetAllBookCategoryQuery request,
        CancellationToken cancellationToken)
    {
        // Query the database
        var bookCategories = await _rep.ListAsync(cancellationToken);

        // convert data objects to DTO objects
        var data = _mapper.Map<List<BookCategoryDto>>(bookCategories);

        // return list of DTO objects
        return data;
    }
}
