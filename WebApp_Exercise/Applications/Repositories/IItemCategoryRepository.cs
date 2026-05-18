using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:商品カテゴリのCRUD操作インターフェイス
/// </summary>
public interface IItemCategoryRepository
{
    List<ItemCategory> FindAll();
    ItemCategory? FindById(int id);
}