using System;
using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class CommonController : Controller
{
    private readonly MyContext _db;

    public CommonController(MyContext db)
    {
        _db = db;
    }

    public IActionResult Another()
    {
        return View();
    }

    public IActionResult NoLayout()
    {
        return View();
    }

    public IActionResult Nest()
    {
        return View();
    }

    public IActionResult List()
    {
        return View(_db.Books);
    }

    public IActionResult List2()
    {
        return View(_db.Books);
    }
}
