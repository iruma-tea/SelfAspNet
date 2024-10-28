using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SelfAspNet.Models;

namespace SelfAspNet.Helpers;

[HtmlTargetElement("book-link", Attributes = "src")]
public class BookLinkTagHelper : TagHelper
{
    // 属性の準備
    [HtmlAttributeName("src")]
    public Book? Book { get; set; }

    [HtmlAttributeName("attrs")]
    public object Attributes { get; set; } = new();

    // タグヘルパーの実処理(非同期)
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        // 書籍情報が空の場合は出力を破棄
        if (Book == null)
        {
            output.SuppressOutput();
            return;
        }

        // 本来の<book-link>要素をアンカータグに整形
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"https://wings.msn.to/index.php/-/A-03/{Book.Isbn}/");

        // 配下に埋め込む<img>要素を生成
        var builder = new TagBuilder("img");
        builder.MergeAttribute("src", $"https://wings.msn.to/books/{Book.Isbn}/{Book.Isbn}.jpg");
        builder.MergeAttribute("alt", Book.Isbn);
        builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(Attributes));

        var content = await output.GetChildContentAsync();
        output.Content.SetHtmlContent(
            $"<figcaption>{content.GetContent()}</figcaption>"
        );
        output.PreContent.SetHtmlContent(builder.RenderSelfClosingTag());
        output.PreElement.SetHtmlContent("<figure>");
        output.PostElement.SetHtmlContent("</figure>");
    }
}
