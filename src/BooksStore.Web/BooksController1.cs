using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Web;
public class BooksController1 : Controller
{
    // GET: BooksController1
    public ActionResult Index()
    {
        return View();
    }

    // GET: BooksController1/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: BooksController1/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BooksController1/Create
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

    // GET: BooksController1/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: BooksController1/Edit/5
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

    // GET: BooksController1/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: BooksController1/Delete/5
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
