using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SelfAspNet.Lib;

public class HttpCookieValueProvider : BindingSourceValueProvider, IEnumerableValueProvider
{
    private readonly IRequestCookieCollection _values;
    private PrefixContainer? _prefixContainer;

    public HttpCookieValueProvider(BindingSource bindingSource, IRequestCookieCollection values, CultureInfo? culture) : base(bindingSource)
    {
        ArgumentNullException.ThrowIfNull(bindingSource);
        ArgumentNullException.ThrowIfNull(values);
        _values = values;
        Culture = culture;
    }

    public CultureInfo? Culture { get; }

    protected PrefixContainer PrefixContainer
    {
        get
        {
            if (_prefixContainer == null)
            {
                _prefixContainer = new PrefixContainer(_values.Keys);
            }
            return _prefixContainer;
        }
    }

    public override bool ContainsPrefix(string prefix)
    {
        return PrefixContainer.ContainsPrefix(prefix);
    }

    public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(prefix);
        return PrefixContainer.GetKeysFromPrefix(prefix);
    }

    public override ValueProviderResult GetValue(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        if (key.Length == 0)
        {
            return ValueProviderResult.None;
        }
        var values = _values[key];
        if (string.IsNullOrEmpty(values))
        {
            return ValueProviderResult.None;
        }
        else
        {
            return new ValueProviderResult(values, Culture);
        }
    }
}
