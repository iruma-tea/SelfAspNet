using System;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
using SelfAspNet.Filters;

namespace SelfAspNet.Controllers;

// [MyLog] // コントローラ単位の宣言
public class FilterController : Controller
{
    [MyLog]
    public IActionResult index()
    {
        Console.WriteLine($"【Action】アクション本体です。");

        ViewBag.Message = "こんにちは、世界!";
        return View();
    }

    // public override void OnActionExecuting(ActionExecutingContext context)
    // {
    //     Console.WriteLine($"【Before】{context.ActionDescriptor.DisplayName}が実行されます。");
    // }

    // public override void OnActionExecuted(ActionExecutedContext context)
    // {
    //     Console.WriteLine($"【After】{context.ActionDescriptor.DisplayName}が実行されました。");
    // }
}
