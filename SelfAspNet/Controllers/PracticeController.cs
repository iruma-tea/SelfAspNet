using System;
using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class PracticeController : Controller
{
    private readonly MyContext _db;

    public PracticeController(MyContext db)
    {
        _db = db;
    }

    public IActionResult Prac2_1()
    {
        return Content("Hello, World!!");
    }

    public IActionResult Check2_4()
    {
        return View(_db.Books);
    }
}
