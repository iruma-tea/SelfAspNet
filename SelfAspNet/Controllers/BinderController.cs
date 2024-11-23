using System;
using Microsoft.AspNetCore.Mvc;
using SelfAspNet.Lib;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class BinderController : Controller
{
    private readonly MyContext _db;
    private readonly IWebHostEnvironment _host;

    public BinderController(MyContext db, IWebHostEnvironment host)
    {
        _db = db;
        _host = host;
    }

    public IActionResult CreateMulti()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMulti(IEnumerable<Book> list)
    {
        for (var i = 0; i < list.Count(); i++)
        {
            var b = list.ElementAt(i);
            // ISBNコードが未入力の行はスキップ
            if (string.IsNullOrEmpty(b.Isbn))
            {
                foreach (var key in new[] { "Isbn", "Title", "Price", "Publisher", "Published" })
                {
                    ModelState.Remove($"list[{i}].{key}");
                }
                continue;
            }
            _db.Books.Add(b);
        }
        if (ModelState.IsValid)
        {
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(CreateMulti));
        }
        else
        {
            return View();
        }
    }

    public IActionResult CreateMulti2()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMulti2(IDictionary<string, Book> list)
    {
        foreach (var e in list)
        {
            if (string.IsNullOrEmpty(e.Value.Isbn))
            {
                ModelState.Remove($"list[{e.Key}].Key");
                foreach (var key in new[] { "Isbn", "Title", "Price", "Publisher", "Published" })
                {
                    ModelState.Remove($"list[{e.Key}].Value.{key}");
                }
                continue;
            }
            _db.Books.Add(e.Value);
        }
        if (ModelState.IsValid)
        {
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(CreateMulti2));
        }
        else
        {
            return View();
        }
    }

    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload(List<IFormFile>? upFiles)
    {
        // ファイルが指定されていない場合はエラー
        if (upFiles == null || upFiles.Count == 0)
        {
            ModelState.AddModelError(string.Empty, "ファイルが指定されていません。");
            return View();
        }
        // アップロードに成功したファイル数
        var success = 0;
        var ps = _db.Photos;

        foreach (var file in upFiles)
        {
            var name = file.FileName;
            // アップロードファイルのサイズ、種類をチェック
            var ext = new[] { ".jpg", ".jpeg", ".png" };
            if (!ext.Contains(Path.GetExtension(name)))
            {
                ModelState.AddModelError(string.Empty, $"拡張子は.png、.jpgでなければいけません({name})");
                continue;
            }
            if (file.Length > 1024 * 1024)
            {
                ModelState.AddModelError(string.Empty, $"サイズは1mb以内でなければいけません({name})");
                continue;
            }

            // アップロードファイルの保存先
            var path = @$"{_host.ContentRootPath}/Data/{name}";
            // FileStream経由でアップロードファイルを複製
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            // データベースに保存する場合
            using var memory = new MemoryStream();
            await file.CopyToAsync(memory);
            ps.Add(new Photo
            {
                Name = Path.GetFileName(file.FileName),
                ContentType = file.ContentType,
                Content = memory.ToArray()
            });
            success++;
        }
        await _db.SaveChangesAsync();
        // 成功メッセージを生成&フォームを再描画
        ViewBag.Message = $"{success}個のファイルをアップロードしました。";
        return View();
    }

    public IActionResult Custom()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Custom(
        [ModelBinder(typeof(DateModelBinder))]
        DateTime current)
    {
        return Content($"入力値：{current.ToShortDateString()}");
    }
}
