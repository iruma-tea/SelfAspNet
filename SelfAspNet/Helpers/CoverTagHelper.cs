using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SelfAspNet.Helpers;

// タグヘルパーの構成を宣言
[HtmlTargetElement("cover", Attributes = "isbn", TagStructure = TagStructure.WithoutEndTag)]
public class CoverTagHelper : TagHelper
{
    // isbn属性をIsbnプロパティに割り当て
    [HtmlAttributeName("isbn")]
    public string Isbn { get; set; } = string.Empty;

    // タグヘルパーの本体
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // タグ名を修正
        output.TagName = "img";
        // 属性を追加
        output.Attributes.SetAttribute("src", $"https://wings.msn.to/books/{Isbn}/{Isbn}.jpg");
        output.Attributes.SetAttribute("alt", Isbn);
    }
}
