using WebApp_Exercise.Applications.Domains;
namespace WebApp_Exercise.Applications.Services;
/// <summary>
/// 商品登録サービスインターフェイス
/// </summary>
public interface IItemRegisterService
{
    /// <summary>
    /// 商品カテゴリの一覧を取得する
    /// </summary>
    /// <returns>商品カテゴリリスト</returns>
    List<ItemCategory> GetItemCategories();

    ItemCategory GetItemCategoryById(int id);

    void Exists(string name);
    void Register(Item item);
}