using BooksStore.Core.BookAggregate;
using BooksStore.Core.BookAggregate.Commands;
using BooksStore.Domain.Core.Bus;
using BooksStore.SharedKernel.Interfaces;
using BooksStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.Web;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IRepository<Book> _rep;
    private readonly IMediatorHandler _bus;

    public BooksController(IMediatorHandler bus, IRepository<Book> rep)
    {
        _rep = rep ?? throw new ArgumentNullException(nameof(rep));
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<List<Book>> Get()
    {
        var books = await _rep.ListAsync();
        return books;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    [Route("newbook")]
    public async Task<List<Book>> CreateRandomBook()
    {
        var title = Guid.NewGuid().ToString();
        var price = 100.00m;
        var book = new Book(title, price);
        await _rep.AddAsync(book);
        var books = await _rep.ListAsync();
        return books;
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] BookViewModel book)
    {
        var createBookCommand = new CreateBookCommand( book.Title, book.ImageUrl, book.Price);

        _bus.SendCommand(createBookCommand);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
