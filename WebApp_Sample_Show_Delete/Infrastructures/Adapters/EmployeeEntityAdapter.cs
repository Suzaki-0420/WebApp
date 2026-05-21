using WebApp_Sample_Show_Delete.Applications.Adapters;
using WebApp_Sample_Show_Delete.Applications.Domains;
using WebApp_Sample_Show_Delete.Infrastructures.Entities;
namespace WebApp_Sample_Show_Delete.Infrastructures.Adapters;
/// <summary>
/// ドメインオブジェクト:EmployeeとEmployeeEntityの相互変換インターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeEntity</typeparam>
public class EmployeeEntityAdapter :
IConverter<Employee, EmployeeEntity>, IRestorer<Employee, EmployeeEntity>
{
    /// <summary>
    /// ドメインオブジェクト:EmployeeをEmployeeEntityに変換する
    /// </summary>
    /// <param name="domain">ドメインモデル:従業員</param>
    /// <returns>EmployeeEntity</returns>
    public EmployeeEntity Convert(Employee domain)
    {
        var entity = new EmployeeEntity
        {
            EmpName = domain.Name
        };
        if (domain.Id != null)
        {
            entity.EmpId = domain.Id.Value;
        }
        if (domain.Department != null)
        {
            entity.DeptId = domain.Department.Id;
        }
        return entity;
    }

    /// <summary>
    /// EmployeeEntityからドメインオブジェクト:Employeeを復元する
    /// </summary>
    /// <param name="target">EmployeeEntity</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Employee Restore(EmployeeEntity target)
    {
        Console.WriteLine($"targetのEmpIdチェック：{target.EmpId}");
        Department? department = new Department(target.Department.DeptId, target.Department.DeptName);

        var employee = new Employee(
            target.EmpId,
            target.EmpName,
            department
        );
        Console.WriteLine($"エンティティEmpIdチェック：{employee.Id}");
        Console.WriteLine($"エンティティ内容チェック：{employee}");
        return employee;
    }
}