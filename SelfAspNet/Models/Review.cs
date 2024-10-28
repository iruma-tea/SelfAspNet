using System;
using System.ComponentModel.DataAnnotations;

namespace SelfAspNet.Models;

public class Review
{
    public int Id { get; set; }
    [Display(Name = "名前")]
    public string Name { get; set; } = String.Empty;
    [Display(Name = "レビュー")]
    public string Body { get; set; } = String.Empty;
    [Display(Name = "更新日")]
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    [Display(Name = "書籍")]
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
