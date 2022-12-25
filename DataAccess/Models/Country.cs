using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("country")]
[Index(nameof(CountryId))]
[Index(nameof(Name))]
public class Country
{
    [Key]
    [MaxLength(2)]
    [Column("code", TypeName = "varchar(2)")]
    public string CountryId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; }

    public ICollection<Company> Companies { get; set; }
}
