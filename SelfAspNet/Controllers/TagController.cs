using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public async Task<IActionResult> SelectGroup()
    {
        var articles = _db.Articles.Select(a => new
        {
            Url = a.Url,
            Title = a.Title,
            Category = a.Category
        });
        ViewBag.Opts = new SelectList(articles, "Url", "Title", null, "Category");
        return View(await _db.Articles.FindAsync(1));
    }
}
