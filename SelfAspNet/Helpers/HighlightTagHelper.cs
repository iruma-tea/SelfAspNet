using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SelfAspNet.Helpers;

[HtmlTargetElement("highlight")]
[HtmlTargetElement(Attributes = "asp-highlight")]
public class HighlightTagHelper : TagHelper
{
    [HtmlAttributeName("asp-highlight")]
    public string? BackgroundColor { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (output.TagName == "highlight")
        {
            output.TagName = "span";
        }
        // 現在の要素にstyle属性を付与
        output.Attributes.Add("style", $"background-color: {BackgroundColor ?? "#ff0"}");
    }
}
