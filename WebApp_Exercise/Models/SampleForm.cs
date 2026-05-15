using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SampleForm
{
    [Display(Name = "氏名")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    public string? Name { get; set; } //氏名プロパティ
    [Display(Name = "年齢")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 120, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int? Age { get; set; } //年齢プロパティ

    [Display(Name = "都道府県")]
    [Range(1, 3, ErrorMessage = "{0}を選択してください。")]
    public int PrefecturesId { get; set; }

    public List<SelectListItem> PrefecturesList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "北海道", Value= "1" },
        new SelectListItem{ Text= "青森県", Value= "2" },
        new SelectListItem{ Text= "岩手県", Value= "3" },
    }; //HTMLで表示するプルダウンに入れるやつ
}