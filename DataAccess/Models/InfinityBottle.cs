using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("infinity_bottle")]
[Index(nameof(BottleName))]
public class InfinityBottle
{
    [Key]
    [Column("id")]
    public int InfinityBottleId { get; set; }

    [Required]
    [Column("bottle_name")]
    public String BottleName { get; set; }

    [Required]
    [Column("bottle_size")]
    public int BottleSize { get; set; }

    [Required]
    [Column("number_of_bottles")]
    public int? NumberOfBottles { get; set; }

    [Required]
    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly? EndDate { get; set; }
}
