using System;
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
}
