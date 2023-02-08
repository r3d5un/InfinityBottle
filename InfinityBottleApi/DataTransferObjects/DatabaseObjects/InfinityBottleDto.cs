using System.ComponentModel.DataAnnotations;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class InfinityBottleDto
{
    [Key]
    public int InfinityBottleId { get; set; }

    [Required]
    public String BottleName { get; set; }

    [Required]
    public int BottleSize { get; set; }

    [Required]
    public int? NumberOfBottles { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
