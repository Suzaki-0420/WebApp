using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Exercise.Models;

public class Op03Form
{
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 1000, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int value1 { get; set; }

    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 1000, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int value2 { get; set; }

    [Display(Name = "計算の種類")]
    [Required(ErrorMessage = "{0}が選択されていません。")]
    [Range(1, 5, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int opt { get; set; }

    public List<SelectListItem> OptIDList { get; set; } = new List<SelectListItem>
    {
        new SelectListItem{ Text="--選択されていません--", Value="0" , Selected = true },
        new SelectListItem{ Text= "足し算", Value= "1" },
        new SelectListItem{ Text= "引き算", Value= "2" },
        new SelectListItem{ Text= "掛け算", Value= "3" },
        new SelectListItem{ Text= "割り算", Value= "4" },
        new SelectListItem{ Text= "あまり？", Value= "5" },
    };

    public int Answer { get; set; } = 0;
}