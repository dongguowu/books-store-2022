using BooksStore.Core.BookAggregate;
using BooksStore.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.Web;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
  private readonly IRepository<Book> _rep;

  public BooksController(IRepository<Book> rep)
  {
    _rep = rep;
  }

  // GET: api/<ValuesController>
  [HttpGet]
  public async Task<List<Book>> Get()
  {
    var title = Guid.NewGuid().ToString();
    var price = 100.00m;
    var book = new Book(title, price);
    await _rep.AddAsync(book);
    var books = await _rep.ListAsync(); 
    //return new string[] { "value1", "value2" };
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
  public void Post([FromBody] string value)
  {
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
