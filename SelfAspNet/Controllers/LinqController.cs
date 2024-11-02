using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Controllers;

public class LinqController : Controller
{
    private readonly MyContext _db;

    public LinqController(MyContext db)
    {
        _db = db;
    }

    public IActionResult Basic2()
    {
        var bs = from b in _db.Books
                 where b.Price < 3000
                 select new { Title = b.Title, Price = b.Price };
        return View(bs);
    }

    public IActionResult List()
    {
        return View(_db.Books);
    }

    public IActionResult Basic()
    {
        // メソッド構文
        var bs = _db.Books.Where(b => b.Price < 3000).Select(b => b.Title);
        // クエリー構文
        // var bs = from b in _db.Books where b.Price < 3000 select b.Title;
        return View(bs);
    }

    public IActionResult Contains()
    {
        var bs = _db.Books.Where(b => b.Title.Contains("JavaScript"));
        return View("Items", bs);
    }

    public IActionResult StartsWith()
    {
        var bs = _db.Books.Where(b => b.Title.StartsWith("独習"));
        return View("Items", bs);
    }

    public IActionResult Selection()
    {
        var bs = _db.Books.Where(b => new int[] { 3, 9 }.Contains(b.Published.Month));
        return View("List", bs);
    }

    public IActionResult Between()
    {
        var bs = _db.Books.Where(b => 4000 <= b.Price && b.Price <= 4500);
        return View("Items", bs);
    }

    public IActionResult BetweenAnd()
    {
        var bs = _db.Books.Where(b => b.Price >= 4000).Where(b => b.Price <= 4500);
        return View("Items", bs);
    }

    public IActionResult Regex()
    {
        var reg = new Regex("\\d");
        var bs = _db.Books.AsEnumerable().Where(b => reg.IsMatch(b.Title)).ToList();
        return View("List", bs);
    }

    public async Task<IActionResult> Single()
    {
        var bs = await _db.Books.SingleAsync(b => b.Isbn == "978-4-7981-8094-6");
        return Content(bs.Title);
    }

    public async Task<IActionResult> Exists()
    {
        var result = await _db.Books.AnyAsync(b => b.Price >= 4000);
        return Content(result.ToString());
    }

    public IActionResult Filter(string keyword, bool? released)
    {
        var bs = _db.Books.Select(b => b);
        // [キーワード]欄が空でない場合、その内容で部分一致検索
        if (!string.IsNullOrEmpty(keyword))
        {
            bs = bs.Where(b => b.Title.Contains(keyword));
        }
        // [刊行済み]がチェック状態の場合、今日以前の書籍で絞込
        if (released.HasValue && released.Value)
        {
            bs = bs.Where(b => b.Published <= DateTime.Now);
        }
        return View(bs);
    }

    public IActionResult Order()
    {
        var bs = _db.Books.OrderByDescending(b => b.Price).ThenBy(b => b.Published);
        return View("List", bs);
    }

    public IActionResult SortGrid(string sort)
    {
        // ソートキー／順序を識別するためのキー文字列を設定
        ViewBag.Isbn = sort == "Isbn" ? "dIsbn" : "Isbn";
        ViewBag.Title = string.IsNullOrEmpty(sort) ? "dTitle" : "";
        ViewBag.Price = sort == "Price" ? "dPrice" : "Price";
        ViewBag.Publisher = sort == "Publisher" ? "dPublisher" : "Publisher";
        ViewBag.Published = sort == "Published" ? "dPublished" : "Published";
        ViewBag.Sample = sort == "Sample" ? "dSample" : "Sample";

        var bs = _db.Books.Select(b => b);
        // 渡されたキー文字列に基づいて、ソート式を選択
        bs = sort switch
        {
            "Isbn" => bs.OrderBy(b => b.Isbn),
            "Title" => bs.OrderBy(b => b.Title),
            "Price" => bs.OrderBy(b => b.Price),
            "Publisher" => bs.OrderBy(b => b.Publisher),
            "Published" => bs.OrderBy(b => b.Published),
            "Sample" => bs.OrderBy(b => b.Sample),
            "dIsbn" => bs.OrderByDescending(b => b.Isbn),
            "dTitle" => bs.OrderByDescending(b => b.Title),
            "dPrice" => bs.OrderByDescending(b => b.Price),
            "dPublisher" => bs.OrderByDescending(b => b.Publisher),
            "dPublished" => bs.OrderByDescending(b => b.Published),
            "dSample" => bs.OrderByDescending(b => b.Sample),
            _ => bs.OrderBy(b => b.Title)
        };
        return View(bs);
    }

    public IActionResult Select()
    {
        var bs = _db.Books.OrderByDescending(b => b.Published).Select(b => new SummaryBookView(
            b.Title.Substring(0, 7) + "...",
            (int)(b.Price * 0.9),
            b.Published <= DateTime.Now ? "発売中" : "発売予定"
        ));

        return View(bs);
    }

    public IActionResult Skip()
    {
        var bs = _db.Books.OrderBy(b => b.Published).Skip(2).Take(3);
        return View("List", bs);
    }

    public IActionResult Page(int id = 1)
    {
        var pageSize = 3;
        var pageNum = id - 1;
        var bs = _db.Books.OrderBy(b => b.Published).Skip(pageSize * pageNum).Take(pageSize);
        return View("List", bs);
    }

    public async Task<IActionResult> First()
    {
        var bs = await _db.Books.OrderBy(b => b.Published).FirstAsync();
        return View("Details", bs);
    }

    public IActionResult Group()
    {
        var bs = _db.Books.GroupBy(b => b.Publisher);
        return View(bs);
    }

    public IActionResult GroupMini()
    {
        var bs = _db.Books.GroupBy(
            b => b.Publisher,
            b => new MiniBook(b.Title, b.Price)
        );
        return View(bs);
    }

    public IActionResult GroupMulti()
    {
        var bs = _db.Books.GroupBy(b => new BookGroup(
            b.Publisher,
            b.Published.Year
        ));
        return View(bs);
    }

    public IActionResult Having()
    {
        var bs = _db.Books.GroupBy(b => b.Publisher)
            .Where(group => group.Average(b => b.Price) >= 3000)
            .Select(group => new HavingBook(group.Key, (int)group.Average(b => b.Price)));
        return View(bs);
    }

    public IActionResult HavingSort()
    {
        var bs = _db.Books
            .GroupBy(b => b.Publisher)
            .OrderBy(group => group.Average(b => b.Price))
            .Select(group => new HavingBook(group.Key, (int)group.Average(b => b.Price)));
        return View("Having", bs);
    }

    public IActionResult Join()
    {
        var rs = _db.Books
            .Join(_db.Reviews, b => b.Id, rev => rev.BookId, (b, rev) => new BookReviewView(b.Title, rev.Body));
        return View(rs);
    }

    public async Task<IActionResult> Update()
    {
        // foreach (var b in _db.Books.Where(b => b.Publisher == "翔泳社"))
        // {
        //     b.Price = (int)(b.Price * 0.8);
        // }
        // await _db.SaveChangesAsync();
        await _db.Books.Where(b => b.Publisher == "翔泳社")
            .ExecuteUpdateAsync(setters => setters.SetProperty(b => b.Price, b => (int)(b.Price * 0.8)));
        return Content("更新しました。");
    }

    public async Task<IActionResult> Insert()
    {
        _db.Reviews.Add(
            new Review
            {
                Name = "藤井友美",
                Body = "しっかり勉強したい人向けの本です。最初に...",
                LastUpdated = new DateTime(2024, 05, 17),
                Book = new Book
                {
                    Isbn = "978-4-7981-6849-4",
                    Title = "独習 PHP",
                    Price = 3740,
                    Publisher = "翔泳社",
                    Published = new DateTime(2021, 06, 14),
                    Sample = true
                }
            }
        );
        await _db.SaveChangesAsync();
        return Content("データを追加しました。");
    }

    public async Task<IActionResult> Insert2()
    {
        var book = await _db.Books.FindAsync(1);
        _db.Reviews.Add(new Review
        {
            Name = "木村裕二",
            Body = "最近は、意外と書き方が変わっていて勉強になった。",
            LastUpdated = new DateTime(2024, 06, 03),
            Book = book!
        });
        await _db.SaveChangesAsync();

        return Content("レビューを追加しました。");
    }

    public async Task<IActionResult> Delete()
    {
        var b = await _db.Books.FindAsync(1);
        // var b = await _db.Books.Include(b => b.Reviews).SingleAsync(b => b.Id == 1);
        _db.Books.Remove(b!);
        await _db.SaveChangesAsync();
        return Content("データを削除しました。");
    }

    public async Task<IActionResult> Transaction()
    {
        _db.Books.Add(new Book
        {
            Isbn = "978-4-297-13919-3",
            Title = "3ステップで学ぶMySQL入門",
            Price = 2860,
            Publisher = "技術評論社",
            Published = new DateTime(2024, 01, 25),
            Sample = true
        });

        _db.Books.Add(new Book
        {
            Isbn = "978-4-7981-8094-6",
            Title = null,
            Price = 3960,
            Publisher = "翔泳社",
            Published = new DateTime(2024, 02, 15),
            Sample = true
        });
        await _db.SaveChangesAsync();
        return Content("データを追加しました。");
    }

    public async Task<IActionResult> Transaction2()
    {
        using (var tx = _db.Database.BeginTransaction())
        {
            try
            {
                _db.Books.Add(
                    new Book
                    {
                        Isbn = "978-4-297-13919-3",
                        Title = "3ステップで学ぶMySQL入門",
                        Price = 2860,
                        Publisher = "技術評論社",
                        Published = new DateTime(2024, 01, 25),
                        Sample = true
                    }
                );
                await _db.SaveChangesAsync();
                _db.Books.Where(b => b.Publisher == "翔泳社")
                    .ExecuteUpdate(setters => setters.SetProperty(b => b.Price, b => (int)(b.Price * 0.8)));
                tx.Commit();
                return Content("データベース処理が正常終了しました。");
            }
            catch (Exception)
            {
                tx.Rollback();
                return Content("データベース処理に失敗しました。");
            }
        }
    }

    public async Task<IActionResult> ViewModel(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _db.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        var list = _db.Books.Select(b => new { Publisher = b.Publisher }).Distinct();

        return View(new SelectView
        {
            Book = book,
            Publishers = new SelectList(
                list, "Publisher", "Publisher", book.Publisher
            )
        });
    }
}
