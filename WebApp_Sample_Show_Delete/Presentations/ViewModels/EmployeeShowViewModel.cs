using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Sample_Show_Delete.Applications.Domains;
namespace WebApp_Sample_Show_Delete.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class EmployeeShowViewModel
{

    [Display(Name = "社員ID")]
    public int? Id { get; set; } = 0;

    /// <summary>
    /// 社員名
    /// </summary>
    [Display(Name = "氏名")]
    public string? Name { get; set; } = string.Empty;
    [Display(Name = "部署")]
    public string? DeptName { get; set; } = string.Empty;


    public EmployeeShowViewModel(int? id, string? name, string? deptname)
    {
        Id = id;
        Name = name;
        DeptName = deptname;
    }
}