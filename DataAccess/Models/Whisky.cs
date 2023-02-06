using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("whiskies")]
[Index(nameof(Name))]
public class Whisky
{
    [Key]
    [Column("id")]
    public int WhiskyId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; }

    [Column("brand_id")]
    [ForeignKey("FK_Whisky_Brand")]
    public int BrandId { get; set; }

    [Column("category_id")]
    [ForeignKey("FK_Whisky_Category")]
    public int CategoryId { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("abv")]
    public int ABV { get; set; }

    [Column("price")]
    public double? Price { get; set; }
}
