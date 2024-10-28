using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SelfAspNet.Models;

namespace SelfAspNet.Helpers;

public class MetaTagHelperComponent : TagHelperComponent
{
    // データベースコンテキストを準備
    private readonly MyContext _db;

    public MetaTagHelperComponent(MyContext db)
    {
        _db = db;
    }

    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // 現在のコントローラ/アクションを取得
        var controller = ViewContext?.RouteData.Values["controller"]?.ToString();
        var action = ViewContext?.RouteData.Values["action"]?.ToString();
        // <head>要素が対象の時に編集作業を開始
        if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
        {
            var metas = await _db.Metas.Where(c => c.Controller == controller && c.Action == action).ToListAsync();
            foreach (var meta in metas)
            {
                output.PostContent.AppendHtml($"<meta name=\"{meta.Name}\" content=\"{meta.Content}\" />");
            }
        }
    }
}
