using System;
using System.ComponentModel.DataAnnotations;

namespace SelfAspNet.Models;

public class Author
{
    public int Id { get; set; }

    [Display(Name = "ペンネーム")]
    public string PenName { get; set; } = String.Empty;

    [Display(Name = "ユーザー")]
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public ICollection<Book> Books { get; } = new List<Book>();

}
