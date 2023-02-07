using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class WhiskyDto
{
    [Key]
    public int WhiskyId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [ForeignKey("FK_Whisky_Brand")]
    public int BrandId { get; set; }

    [ForeignKey("FK_Whisky_Category")]
    public int CategoryId { get; set; }

    public int? Age { get; set; }

    public int ABV { get; set; }

    public double? Price { get; set; }
}
