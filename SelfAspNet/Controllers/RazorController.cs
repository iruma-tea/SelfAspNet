using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;
public class RazorController : Controller
{
    private readonly MyContext _db;

    public RazorController(MyContext db)
    {
        _db = db;
    }

    public IActionResult Attr()
    {
        return View();
    }

    public IActionResult Replace()
    {
        return View();
    }

    public IActionResult Suppress()
    {
        return View();
    }

    public IActionResult StatIf()
    {
        var b = _db.Books.Single(b => b.Isbn == "978-4-7981-8094-6");
        return View(b);
    }
}
