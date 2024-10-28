using System;
using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Models;

namespace SelfAspNet.Lib;

public class MetaViewComponent : ViewComponent
{
    private readonly MyContext _db;

    public MetaViewComponent(MyContext db)
    {
        _db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync(HttpContext context)
    {
        var id = context.GetRouteValue("id")?.ToString();
        // ルートパラメーターidが存在しない場合、Baseビューを採用
        if (id == null)
        {
            return View("Base");
        }
        var book = await _db.Books.FindAsync(Int32.Parse(id));
        if (book == null)
        {
            return View("Base");
        }
        return View(book);
    }
}
