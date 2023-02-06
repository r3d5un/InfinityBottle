using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("category")]
[Index(nameof(Name))]
[Index(nameof(Region))]
[Index(nameof(SubCategory))]
public class Category
{
    [Key]
    [Column("id")]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }

    [MaxLength(50)]
    [Column("region", TypeName = "varchar(50)")]
    public string? Region { get; set; }

    [MaxLength(50)]
    [Column("sub_category", TypeName = "varchar(50)")]
    public string? SubCategory { get; set; }

    public ICollection<Whisky> Whiskies { get; set; }
}
