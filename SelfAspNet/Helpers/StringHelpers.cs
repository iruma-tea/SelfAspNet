using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SelfAspNet.Helpers;

public static class StringHelpers
{
    // public static string Truncate(string text, int length = 15, string omission = "...")
    public static string Truncate(this IHtmlHelper helper, string text, int length = 15, string omission = "...")
    {
        if (text.Length <= length) { return text; }
        return text.Substring(0, length - 1) + omission;
    }

    public static IHtmlContent Cover(this IHtmlHelper helper, string isbn, object? htmlAttrs = null)
    {
        // <img>要素を生成
        var builder = new TagBuilder("img");
        // src,alt属性を付与
        builder.MergeAttribute("src", $"https://wings.msn.to/books/{isbn}/{isbn}.jpg");
        builder.MergeAttribute("alt", isbn);
        // その他の属性を付与
        builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrs));
        return builder.RenderSelfClosingTag();
    }
}
