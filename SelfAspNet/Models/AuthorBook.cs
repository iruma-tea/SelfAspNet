using System;

namespace SelfAspNet.Models;

public class AuthorBook
{
    public Author Author { get; set; } = null!;
    public Book Book { get; set; } = null!;
}
