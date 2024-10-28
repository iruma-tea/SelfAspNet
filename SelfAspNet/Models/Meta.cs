using System;

namespace SelfAspNet.Models;

public class Meta
{
    public int Id { get; set; }

    public string Controller { get; set; } = String.Empty;
    public string Action { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
}
