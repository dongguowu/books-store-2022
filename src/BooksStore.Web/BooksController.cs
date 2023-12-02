using AutoMapper;
using AutoMapper.QueryableExtensions;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.BookAggregate.AutoMapper;
using BooksStore.Core.BookAggregate.Commands;
using BooksStore.Core.BookAggregate.ViewModel;
using BooksStore.Domain.Core.Bus;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.Web;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IRepository<Book> _rep;
    private readonly IMediatorHandler _bus;
    private readonly IMapper _mapper;

    public BooksController(IMediatorHandler bus, IRepository<Book> rep, IMapper mapper)
    {
        _rep = rep ?? throw new ArgumentNullException(nameof(rep));
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<IEnumerable<BookViewModel>> Get()
    {
        var books = (await _rep.ListAsync()).Select(b => _mapper.Map<BookViewModel>(b));
        return (IEnumerable<BookViewModel>)books;
        //return (IEnumerable<Book>)((IQueryable)(await _rep.ListAsync())).ProjectTo<BookViewModel>(_mapper.ConfigurationProvider);
    }

    // GET: api/<ValuesController>
    [HttpGet]
    [Route("newbook")]
    public async Task<IEnumerable<Book>> CreateRandomBook()
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
        //var createBookCommand = new CreateBookCommand( book.Title, book.ImageUrl, book.Price);

        _bus.SendCommand(_mapper.Map<CreateBookCommand>(book));
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
