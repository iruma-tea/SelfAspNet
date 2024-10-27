using System;

namespace SelfAspNet.Helpers;

public static class StringHelpers
{
    public static string Truncate(string text, int length = 15, string omission = "...")
    {
        if (text.Length <= length) { return text; }
        return text.Substring(0, length - 1) + omission;
    }
}
