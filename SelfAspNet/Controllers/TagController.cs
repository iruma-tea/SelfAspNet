using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelfAspNet.Helpers;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class TagController : Controller
{
    private readonly MyContext _db;
    private readonly ITagHelperComponentManager _manager;

    public TagController(MyContext db, ITagHelperComponentManager manager)
    {
        _db = db;
        _manager = manager;
    }

    public IActionResult Anchor()
    {
        return View();
    }

    public IActionResult Path()
    {
        return View();
    }

    public async Task<IActionResult> SelectGroup()
    {
        var articles = _db.Articles.Select(a => new { Url = a.Url, Title = a.Title, Category = a.Category });
        ViewBag.Opts = new SelectList(articles, "Url", "Title", null, "Category");
        return View(await _db.Articles.FindAsync(1));
    }

    public IActionResult Raw()
    {
        ViewBag.Message = "<h3>WINGSプロジェクト</h3><img src=\"https://wings.msn.to/image/wings.jpg\" alt=\"ロゴ\" />";
        return View();
    }

    public IActionResult Image()
    {
        return View();
    }

    public IActionResult Import()
    {
        return View();
    }

    public IActionResult Cache(int num1, int num2)
    {
        ViewBag.Num1 = num1;
        ViewBag.Num2 = num2;
        return View();
    }

    public IActionResult Custom()
    {
        return View();
    }

    public async Task<IActionResult> MyRadio(int? id = 1)
    {
        // 重複なしの出版社名を取得
        ViewBag.Pubs = _db.Books.Select(b => new SelectListItem { Value = b.Publisher, Text = b.Publisher }).Distinct();
        // 引数idに合致する書籍情報を取得
        return View(await _db.Books.FindAsync(id));
    }

    public IActionResult Func()
    {
        return View();
    }

    public IActionResult Cover()
    {
        ViewBag.Isbn = "978-4-7981-7556-0";
        return View();
    }

    public async Task<IActionResult> Link(int id = 1)
    {
        return View(await _db.Books.FindAsync(id));
    }

    public IActionResult Highlight()
    {
        return View();
    }

    public async Task<IActionResult> For(int id = 1)
    {
        return View(await _db.Books.FindAsync(id));
    }

    public IActionResult Index()
    {
        _manager.Components.Add(new MetaTagHelperComponent(_db));
        return View();
    }

}
