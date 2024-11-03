using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SelfAspNet.Models;

public class Book
{
    public int Id { get; set; }
    [DataType(DataType.ImageUrl)]
    // [UIHint("Isbn")]
    [RegularExpression("978-4-[0-9]{2,5}-[0-9]{2,5}-[0-9X]", ErrorMessage = "{0}の形式が違っています。")]
    // [Remote("UniqueIsbn", "Books")]
    [Display(Name = "ISBN")]
    public string Isbn { get; set; } = String.Empty;

    [Required(ErrorMessage = "{0}は必須です。")]
    [StringLength(50, ErrorMessage = "{0}は{1}文字以内で指定してください。")]
    [Display(Name = "タイトル")]
    public string Title { get; set; } = String.Empty;
    [DataType(DataType.Currency)]
    [Range(10, 10000, ErrorMessage = "{0}は{1}～{2}の間で指定してください。")]
    [Display(Name = "価格")]
    public int Price { get; set; }

    [RegularExpression("翔泳社|技術評論社|SBクリエイティブ|日経BP|森北出版", ErrorMessage = "{0}は「{1}」のいずれかでなければなりません。")]
    [Display(Name = "出版社")]
    public string Publisher { get; set; } = String.Empty;

    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2010-01-01", "2029-12-31", ErrorMessage = "{0}は{1:d}～{2:d}の範囲で指定してください。")]
    [Display(Name = "刊行日")]
    public DateTime Published { get; set; }
    [Display(Name = "配布サンプル")]
    public bool Sample { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }

    public ICollection<Review> Reviews { get; } = new List<Review>();
    public ICollection<Author> Authors { get; } = new List<Author>();

    // public virtual ICollection<Review> Reviews { get; } = new List<Review>();
    // public virtual ICollection<Author> Authors { get; } = new List<Author>();
}
