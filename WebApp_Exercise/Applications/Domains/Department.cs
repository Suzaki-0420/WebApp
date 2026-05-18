using WebApp_Exercise.Exeptions;
namespace WebApp_Exercise.Applications.Domains;

//部署のドメインオブジェクト
public class Department
{
    public int? Id { get; private set; } //?でnullを許容、読み取りはどこからでもOK、書き込みはクラス内部だけOK
    public string? Name { get; private set; }

    private const int MaxLength = 20;//最大の文字数（変更されない、外部から上書きできない）

    //コンストラクタ
    public Department(int? id, string? name)
    {
        //部署名のルール（入力必須&最大文字数）のチェック
        validateDepartmentName(name);
        Id = id;
        Name = name;

    }
    public Department(string? name) : this(null, name) { }
    //オーバーロード、Idがnullで渡されたら(null,"営業部")のような形で上のDepartmentコンストラクタに渡す

    public Department(int? id)
    {
        Id = id;
    } //部署番号だけのコンストラクタ→部署Idで検索をかけるときなどに使う

    //部署名チェック（入力必須 & 最大文字数）
    public void validateDepartmentName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("部署名は必須です");
        if (name.Length > MaxLength)
            throw new DomainException($"部署名は{MaxLength}文字以内で入力してください");
    }

    public void ChangeName(string? name)
    {
        // 部署名のルール検証
        validateDepartmentName(name);
        this.Name = name;
    }

    //同じ部署かの検証
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) //まったく同じインスタンス（部署）があったら
        {
            return true; //true（同じ！）を返す
        }
        if (obj is not Department other) //Department型じゃなかったらfalseを返し、Department型のときはotherに格納
        {
            return false;
        }
        return Id == other.Id;
    }

    public override int GetHashCode() => Id?.GetHashCode() ?? 0;
    //idがnullでなければハッシュ値を返す、nullなら0を返す
    public override string ToString() => $"{Id?.ToString() ?? "未登録"}: {Name}";

}