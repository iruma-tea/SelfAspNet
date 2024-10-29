using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class EntityController : Controller
{
    private readonly MyContext _db;

    public EntityController(MyContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Assoc(int id = 1)
    {
        var b = await _db.Books.Include(b => b.Reviews).Include(b => b.Authors).ThenInclude(a => a.User).SingleAsync(b => b.Id == id);
        // var b = await _db.Books.SingleAsync(b => b.Id == id);
        // await _db.Entry(b).Collection(b => b.Reviews).LoadAsync();
        // await _db.Entry(b).Collection(b => b.Authors).LoadAsync();
        return View(b);
    }
}
