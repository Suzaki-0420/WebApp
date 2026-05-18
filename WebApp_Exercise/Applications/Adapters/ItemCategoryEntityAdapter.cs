using WebApp_Exercise.Applications.Adapters;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Exeptions;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise_Answer.Infrastructures.Adapters;

public class ItemCategoryEntityAdapter :
IConverter<ItemCategory, ItemCategoryEntity>, IRestorer<ItemCategory, ItemCategoryEntity>
{

    public ItemCategoryEntity Convert(ItemCategory domain)
    {
        if (domain == null) throw new InternalException("引数domainがnullのため変換できません。");
        return new ItemCategoryEntity
        {
            Id = domain.Id ?? 0,      // null許容（新規は0）
            Name = domain.Name
        };
    }

    public ItemCategory Restore(ItemCategoryEntity target)
    {
        if (target == null)
        {
            throw new InternalException("引数targetがnullのため復元できません。");
        }
        var domain = new ItemCategory(target.Id, target.Name);
        return domain;
    }
}