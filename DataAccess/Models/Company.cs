using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("company")]
[Index(nameof(Name))]
public class Company
{
    [Key]
    [Column("id")]
    public int CompanyId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }

    [MaxLength(100)]
    [Column("address")]
    public string? Address { get; set; }

    [MaxLength(100)]
    [Column("city")]
    public string? City { get; set; }

    [MaxLength(25)]
    [Column("postal_code")]
    public string? PostalCode { get; set; }

    [MaxLength(100)]
    [Column("state")]
    public string? State { get; set; }

    [Column("country")]
    [ForeignKey("FK_Company_Country")]
    public string? CountryId { get; set; }

    public ICollection<Brand> Brands { get; set; }
}
