using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp_Exercise.Models;

public class Exercise07Form
{
    [Display(Name = "値1")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int value1 { get; set; }

    [Display(Name = "値2")]
    [Required(ErrorMessage = "{0}は入力必須です。")]
    [Range(0, 100, ErrorMessage = "{0}は{1}～{2}までの数字で入力してください。")]
    public int value2 { get; set; }

    public int Answer { get; set; } = 0;
}