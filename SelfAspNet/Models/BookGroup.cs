using System.ComponentModel.DataAnnotations;

namespace SelfAspNet.Models;

public record BookGroup(
    [property: Display(Name = "出版社")]
    string Publisher,
    [property: Display(Name = "刊行年")]
    int Year
);
