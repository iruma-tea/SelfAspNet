using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SelfAspNet.Helpers;

[HtmlTargetElement("article")]
[EditorBrowsable(EditorBrowsableState.Never)]
public class ArticleTagHelperComponentTagHelper : TagHelperComponentTagHelper
{
    public ArticleTagHelperComponentTagHelper(ITagHelperComponentManager componentManager, ILoggerFactory loggerFactory) : base(componentManager, loggerFactory)
    { }
}
