using BooksStore.Application.Features.BookCategory.Commands.CreateBookCategory;
using BooksStore.Application.Features.BookCategory.Commands.UpdateBookCategory;
using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<BookCategoryController>
    [HttpGet]
    public async Task<List<BookCategoryDto>> Get()
    {
        var results = await _mediator.Send(new GetAllBookCategoriesQuery());

        return results;
    }

    // GET api/<BookCategoryController>/5
    [HttpGet("{id}")]
    public async Task<BookCategoryDetailDto> GetById(Guid id)
    {
        return (BookCategoryDetailDto)(await _mediator.Send(new GetBookCategoryByIdQuery(id)) ?? new object());
    }

    // POST api/<BookCategoryController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateBookCategoryCommand bookCategory)
    {
        var response = await _mediator.Send(bookCategory);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<BookCategoryController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateBookCategoryCommand bookCategory)
    {
        await _mediator.Send(bookCategory);
        return NoContent();
    }

    // DELETE api/<BookCategoryController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public void Delete(Guid id)
    {
    }
}
