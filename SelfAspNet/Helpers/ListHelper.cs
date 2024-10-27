using System;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SelfAspNet.Helpers;

public static class ListHelper
{
    public static IHtmlContent RadioButtonListFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> exp, IEnumerable<SelectListItem> list, object htmlAttrs)
    {
        // ラジオボタンを束ねるためのStringBuilder
        var span = new StringBuilder();

        // ラムダ式からプロパティの名前/値を取得する
        var provider = helper.ViewContext.HttpContext.RequestServices.GetService(typeof(IModelExpressionProvider)) as ModelExpressionProvider;
        var meta = provider?.CreateModelExpression(helper.ViewData, exp);
        var name = provider?.GetExpressionText(exp);
        var value = (string)meta?.Model!;

        // SelectListItemのリストからラジオボタンを生成
        var i = 1;
        foreach (var item in list)
        {
            // <label>要素の生成
            var label = new TagBuilder("label");
            label.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrs));
            // <label>配下にラジオボタン + テキストを追加
            label.InnerHtml.AppendHtml(
                helper.RadioButton(name, item.Value, item.Value == value, new { id = $"{name}_{i++}" })
            ).AppendHtml(item.Text);
            // 単一の<label>要素をStringBuilderに追加
            using (var writer = new StringWriter())
            {
                label.WriteTo(writer, HtmlEncoder.Default);
                span.Append(writer.ToString());
            }
        }
        return new HtmlString(span.ToString());
    }
}
