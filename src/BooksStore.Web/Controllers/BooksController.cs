using BooksStore.Core.BookAggregate;
using BooksStore.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web.Controllers;
public class BooksController : Controller
{
    private readonly SharedKernel.Interfaces.IReadRepository<Book> _rep;

    public BooksController(IReadRepository<Book> rep)
    {
        _rep = rep;
    }
    // GET: BooksController
    public async Task<ActionResult> Index()
    {
        var books = await _rep.ListAsync();
        return View(books);
    }

    // GET: BooksController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: BooksController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BooksController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BooksController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BooksController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: BooksController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BooksController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
