using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/<BookCategoryController>
    [HttpGet]
    public async Task<List<BookCategoryDto>> Get()
    {
        var results = await _mediator.Send(new GetAllBookCategoryQuery());

        return results;
    }

    // GET api/<BookCategoryController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<BookCategoryController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BookCategoryController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BookCategoryController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
