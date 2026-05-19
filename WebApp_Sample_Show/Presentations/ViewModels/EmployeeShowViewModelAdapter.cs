using WebApp_Sample_Show.Applications.Adapters;
using WebApp_Sample_Show.Applications.Domains;
namespace WebApp_Sample_Show.Presentations.ViewModels;
/// <summary>
/// EmployeeRegisterViewModel(従業員登録ViewModel)を
/// ドメインオブジェクト:Employeeに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeRegisterForm</typeparam>
public class EmployeeShowViewModelAdapter : IConverter<Employee, EmployeeShowViewModel>
{
    /// <summary>
    /// ドメインオブジェクト:EmployeeをEmployeeRegisterViewModelに変換する
    /// </summary>
    /// <param name="target">EmployeeRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Employee</returns>

    public EmployeeShowViewModel Convert(Employee target)
    {
        var employeeshowviewmodel = new EmployeeShowViewModel(target.Id, target.Name);
        return employeeshowviewmodel;
    }
}