using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SelfAspNet.Lib;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class InOptionsAttribute : ValidationAttribute, IClientModelValidator
{
    // 候補リストを表すプライベート変数
    private string _options;

    public InOptionsAttribute(string options)
    {
        _options = options;
        ErrorMessage = "{0}は「{1}」のいずれかの値で指定します。";
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        var attrs = context.Attributes;
        attrs.TryAdd("data-val", "true");
        attrs.TryAdd("data-val-inoptions", FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
        attrs.TryAdd("data-val-inoptions-opts", _options);
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
