using System;

namespace SelfAspNet.Models;

public class Photo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[] Content { get; set; } = null!;
}
