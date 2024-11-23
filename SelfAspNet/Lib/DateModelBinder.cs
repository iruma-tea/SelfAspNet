using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SelfAspNet.Lib;

public class DateModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext context)
    {
        DateTime result;
        try
        {
            result = new DateTime(
                GetDateNumber(context, "year"),
                GetDateNumber(context, "month"),
                GetDateNumber(context, "day")
            );
        }
        catch
        {
            // 不正な日付値の場合はエラーを追加
            context.ModelState.AddModelError(context.ModelName, "適切な日付値を入力してください。");
            return Task.CompletedTask;
        }
        context.Result = ModelBindingResult.Success(result);
        return Task.CompletedTask;
    }

    private static int GetDateNumber(ModelBindingContext context, string type)
    {
        var value = context.ValueProvider.GetValue(
            $"{context.ModelName}.{type}");
        if (value == ValueProviderResult.None) { return 0; }
        int.TryParse((string?)value, out int result);
        return result;
    }
}
