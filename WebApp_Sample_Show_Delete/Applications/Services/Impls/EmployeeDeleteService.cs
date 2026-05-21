using WebApp_Sample_Show_Delete.Applications.Repositories;
using WebApp_Sample_Show_Delete.Applications.Domains;
using WebApp_Sample_Show_Delete.Exceptions;
using WebApp_Sample_Show_Delete.Infrastructures.Context;
namespace WebApp_Sample_Show_Delete.Applications.Services.Impls;
/// <summary>
/// 従業員登録サービスインターフェイスの実装
/// </summary>
public class EmployeeDeleteService : IEmployeeDeleteService
{

    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインオブジェクト:従業員のCRUD操作インターフェイス
    /// </summary>
    private readonly IEmployeeRepository _employeeRepository;
    /// <summary>
    /// ドメインオブジェクト:部署のCRUD操作インターフェイス
    /// </summary>
    private readonly IDepartmentRepository _departmentRepository;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    /// <param name="employeeRepository">従業員のCRUD操作インターフェイス</param>
    /// <param name="departmentRepository">部署のCRUD操作インターフェイス</param>
    public EmployeeDeleteService(
        AppDbContext context,
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {
        _context = context;
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// 指定された部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <returns></returns>
    public Employee GetById(int id)
    {
        var result = _employeeRepository.FindById(id)!;
        if (result == null)
        {
            throw new NotFoundException($"社員Id{id}に該当する社員は存在しません");
        }
        return result;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    public List<Employee> GetEmployees()
    {
        return _employeeRepository.FindAll();
    }

    /// <summary>
    /// 既存の従業員を削除する
    /// </summary>
    /// <param name="employee"></param>
    public void Delete(Employee employee)
    {
        Console.WriteLine($"サービスでのemployee：{employee}");
        try
        {
            // トランザクションの開始
            _context.Database.BeginTransaction();
            // 従業員の登録
            _employeeRepository.Delete(employee);
            // トランザクションのコミット
            _context.Database.CommitTransaction();
        }
        catch
        {
            // トランザクションのロールバック
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}