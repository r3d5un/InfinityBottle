using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class CompanyGetDto
{
    [Key]
    public int CompanyId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(25)]
    public string? PostalCode { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

    public string? CountryId { get; set; }
}
