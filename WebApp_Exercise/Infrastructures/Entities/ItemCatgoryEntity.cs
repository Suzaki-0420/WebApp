//演習16
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

[Table("item_category")]
public class ItemCategoryEntity
{
    [Key] //主キー
    [Column("id")]
    public int? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public List<ItemEntity>? Items { get; set; }
}