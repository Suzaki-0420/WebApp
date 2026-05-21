using WebApp_Sample_Show_Delete.Applications.Domains;
namespace WebApp_Sample_Show_Delete.Applications.Services;

public interface IEmployeeShowService
{
    /// <summary>
    /// すべての社員を取得する
    /// </summary>
    /// <returns></returns>
    List<Employee> GetEmployees();
    //取得したデータをViewに渡す


}