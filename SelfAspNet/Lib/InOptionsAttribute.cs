using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SelfAspNet.Lib;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class InOptionsAttribute : ValidationAttribute
{
    // 候補リストを表すプライベート変数
    private string _options;

    public InOptionsAttribute(string options)
    {
        _options = options;
        ErrorMessage = "{0}は「{1}」のいずれかの値で指定します。";
    }

    // プロパティの表示名と候補値リストでエラーメッセージを整形
    public override string FormatErrorMessage(string name)
    {
        return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _options);
    }

    // 検証の実処理(入力値が候補リストのいずれかであるかをチェックする)
    public override bool IsValid(object? value)
    {
        var v = value as string;
        // 入力値が空の場合は検証をスキップ
        if (string.IsNullOrEmpty(v)) { return true; }
        // カンマ区切りの候補値リストを分解し、入力値valueと比較
        if (_options.Split(",").Any(opt => opt.Trim() == v))
        {
            return true;
        }
        return false;
    }
}
