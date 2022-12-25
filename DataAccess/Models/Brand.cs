using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("brands")]
[Index(nameof(Name))]
public class Brand
{
    [Key]
    [Column("id")]
    public int BrandId { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [ForeignKey("FK_Brands_Distilleries")]
    [Column("company_id")]
    public int CompanyId { get; set; }

    public ICollection<Whisky> Whiskies { get; set; }
}
