using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Lib;

public class ListViewComponent : ViewComponent
{
    private readonly MyContext _db;

    public ListViewComponent(MyContext db)
    {
        _db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync(int price)
    {
        return View(await _db.Books.Where(b => b.Price < price).ToListAsync());
    }
}
