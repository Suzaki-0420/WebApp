using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

public class ItemCategory
{
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    private const int MaxLength = 20;

    //コンストラクタ
    public ItemCategory(int? id, string? name)
    {
        ValidateId(id); //idが条件に合っているかチェック
        ValidateName(name); //nameが条件にあっているかチェック
        Id = id;
        Name = name;
    }

    public ItemCategory(string? name) : this(null, name) { }
    public ItemCategory(int? id) : this(id, null) { }

    //Idのチェック
    public void ValidateId(int? id)
    {
        if (id == null)
        {
            return;
        }

        if (id < 1)
        {
            throw new DomainException("商品カテゴリIdは1以上でなければなりません。");
        }
    }

    public void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("カテゴリ名は必須です");
        if (name.Length > MaxLength)
            throw new DomainException($"カテゴリ名は{MaxLength}文字以内で入力してください");
    }

    //同じもののチェック
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Employee other) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var nameText = string.IsNullOrWhiteSpace(Name) ? "未登録" : Name;
        return $"商品カテゴリId={idText},商品カテゴリ名{nameText}";
    }
}