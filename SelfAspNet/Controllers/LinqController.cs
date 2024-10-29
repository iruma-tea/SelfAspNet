using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class LinqController : Controller
{
    private readonly MyContext _db;

    public LinqController(MyContext db)
    {
        _db = db;
    }

    public IActionResult Basic2()
    {
        var bs = from b in _db.Books
                 where b.Price < 3000
                 select new { Title = b.Title, Price = b.Price };
        return View(bs);
    }

    public IActionResult List()
    {
        return View(_db.Books);
    }

    public IActionResult Basic()
    {
        // メソッド構文
        var bs = _db.Books.Where(b => b.Price < 3000).Select(b => b.Title);
        // クエリー構文
        // var bs = from b in _db.Books where b.Price < 3000 select b.Title;
        return View(bs);
    }

    public IActionResult Contains()
    {
        var bs = _db.Books.Where(b => b.Title.Contains("JavaScript"));
        return View("Items", bs);
    }

    public IActionResult StartsWith()
    {
        var bs = _db.Books.Where(b => b.Title.StartsWith("独習"));
        return View("Items", bs);
    }

    public IActionResult Selection()
    {
        var bs = _db.Books.Where(b => new int[] { 3, 9 }.Contains(b.Published.Month));
        return View("List", bs);
    }

    public IActionResult Between()
    {
        var bs = _db.Books.Where(b => 4000 <= b.Price && b.Price <= 4500);
        return View("Items", bs);
    }

    public IActionResult BetweenAnd()
    {
        var bs = _db.Books.Where(b => b.Price >= 4000).Where(b => b.Price <= 4500);
        return View("Items", bs);
    }

    public IActionResult Regex()
    {
        var reg = new Regex("\\d");
        var bs = _db.Books.AsEnumerable().Where(b => reg.IsMatch(b.Title)).ToList();
        return View("List", bs);
    }

    public async Task<IActionResult> Single()
    {
        var bs = await _db.Books.SingleAsync(b => b.Isbn == "978-4-7981-8094-6");
        return Content(bs.Title);
    }

    public async Task<IActionResult> Exists()
    {
        var result = await _db.Books.AnyAsync(b => b.Price >= 4000);
        return Content(result.ToString());
    }
}
