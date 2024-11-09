using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SelfAspNet.Lib;

public class CsvResult : ActionResult
{
    readonly IEnumerable<object> _list;

    public CsvResult(IEnumerable<object> list)
    {
        _list = list;
    }

    public override void ExecuteResult(ActionContext context)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var res = context.HttpContext.Response;
        res.Headers.ContentType = "text/csv; charset=sjis";
        res.Headers.ContentDisposition = "attachment; filename=\"result.csv\"";
        res.WriteAsync(CreateCSV(_list), Encoding.GetEncoding("Shift_JIS"));
    }

    private static string CreateCSV(IEnumerable<object> list)
    {
        // カンマ区切り文字列を蓄積するためのStringBuilder
        var sb = new StringBuilder();
        foreach (var obj in list)
        {
            var rows = new List<string?>();
            // オブジェクトのすべてのプロパティを取得
            foreach (var prop in obj.GetType().GetProperties())
            {
                // 特定の型のみをリストに追加
                var type = prop.PropertyType;
                if (type.IsPrimitive || type == typeof(String) || type == typeof(DateTime))
                {
                    rows.Add(prop?.GetValue(obj)?.ToString());
                }
            }
            // リストの内容をカンマで連結、末尾に改行文字を加えたものを追加
            sb.AppendLine(string.Join(",", rows.ToArray()));
        }

        return sb.ToString();
    }
}
