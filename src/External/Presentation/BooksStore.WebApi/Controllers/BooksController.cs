using BooksStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IRepository<Book> _rep;

    public BooksController(IRepository<Book> rep)
    {
        _rep = rep;
    }

    // GET: api/<BooksController>
    [HttpGet]
    public async Task<List<Book>> Get()
    {
        return await _rep.ListAsync();
    }

    // GET api/<BooksController>/5
    [HttpGet("{id}")]
    public async Task<Book?> Get(Guid id)
    {
        return await _rep.GetByIdAsync(id);
    }

    // POST api/<BooksController>
    [HttpPost]
    public async Task<Book?> Post([FromBody] Book book)
    {
        return await _rep.AddAsync(book);
    }

    // PUT api/<BooksController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BooksController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
