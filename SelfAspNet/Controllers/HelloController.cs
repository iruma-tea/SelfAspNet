using System;
using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class HelloController : Controller
{
    private readonly MyContext _db;

    public HelloController(MyContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return Content("こんにちは、世界！");
    }

    public IActionResult Show()
    {
        ViewBag.Message = "こんにちは、世界！";
        return View();
    }

    public IActionResult List()
    {
        // データベースから取得した結果をテンプレートに渡す。
        var books = _db.Books;
        return View(books);
    }
}
