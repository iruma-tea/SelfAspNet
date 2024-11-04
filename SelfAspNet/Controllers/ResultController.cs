using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class ResultController : Controller
{
    private readonly MyContext _db;
    private readonly IWebHostEnvironment _host;

    public ResultController(MyContext db, IWebHostEnvironment host)
    {
        _db = db;
        _host = host;
    }

    public IActionResult Template()
    {
        return View("About");
        // return View("Manage/About");
        // return View("../Manage/About");
        // return View("Template/New.cshtml");
        // return View("/Template/New.cshtml");
    }

    public IActionResult AjaxForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AjaxSearch(string keyword, bool? released)
    {
        var bs = _db.Books.Select(b => b);
        if (!string.IsNullOrEmpty(keyword))
        {
            bs = bs.Where(b => b.Title.Contains(keyword));
        }
        if (released.HasValue && released.Value)
        {
            bs = bs.Where(b => b.Published <= DateTime.Now);
        }
        return PartialView("_AjaxResult", bs);
    }

    public IActionResult Move()
    {
        return Redirect("https://wings.msn.to/");
    }

    public IActionResult Local()
    {
        return LocalRedirect("https://wings.msn.to/");
    }

    public async Task<IActionResult> Status(int? id)
    {
        var bs = await _db.Books.FindAsync(id);
        if (bs == null)
        {
            return StatusCode(404);
        }
        return View("../Books/Details", bs);
    }

    public IActionResult Nothing()
    {
        return Empty;
    }

    public IActionResult Plain()
    {
        return Content("こんにちは、世界！", "text/plain", Encoding.UTF8);
    }

    public async Task<IActionResult> Csv()
    {
        var bs = await _db.Books.ToListAsync();
        var data = new StringBuilder();
        bs.ForEach(b =>
            data.Append(string.Format(
                $"{b.Id},{b.Isbn},{b.Title},{b.Price},{b.Publisher},{b.Published}\r\n")
            )
        );
        Response.Headers.Append(
            "Content-Disposition", "attachment;filename=data.csv");
        return Content(data.ToString(), "text/comma-separated-values", Encoding.GetEncoding("UTF-8"));
    }

    public IActionResult Image(int id)
    {
        // 物理パスで指定する場合
        // var path = $"C:/data/images/img_{id}.png";
        // return PhysicalFile(path, "image/png", "sample.png");

        var path = $"/images/img_{id}.png";
        return File(path, "image/png", "sample.png");
    }

    public IActionResult Risk(string path)
    {
        return PhysicalFile(path, "application/octet-stream");
    }
}
