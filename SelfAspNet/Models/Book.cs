using System;

namespace SelfAspNet.Models;

public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; } = String.Empty;
    public string Title { get; set; } = String.Empty;
    public int Price { get; set; }
    public string Publisher { get; set; } = String.Empty;
    public DateTime Published { get; set; }
    public bool Sample { get; set; }
}
