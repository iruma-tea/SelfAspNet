using System;
using System.ComponentModel.DataAnnotations;

namespace SelfAspNet.Models;

public record SummaryBookView
(
    [property: Display(Name = "書名")] string ShortTitle,
    [property: Display(Name = "値引き価格")] int DiscountPrice,
    [property: Display(Name = "状態")] string Released
);