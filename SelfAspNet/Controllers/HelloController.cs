using System;
using Microsoft.AspNetCore.Mvc;

namespace SelfAspNet.Controllers;

public class HelloController : Controller
{
    public IActionResult Index()
    {
        return Content("こんにちは、世界！");
    }

    public IActionResult Show()
    {
        ViewBag.Message = "こんにちは、世界！";
        return View();
    }
}
