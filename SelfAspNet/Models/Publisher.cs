using System.ComponentModel.DataAnnotations;

namespace SelfAspNet.Models;

public enum Publisher
{
    [Display(Name = "翔泳社")]
    SE,
    [Display(Name = "技術評論社")]
    Gihyo,
    [Display(Name = "SBクリエイティブ")]
    SB,
    [Display(Name = "日経BP社")]
    Nikkei,
    [Display(Name = "秀和システム")]
    Shuwa
}
