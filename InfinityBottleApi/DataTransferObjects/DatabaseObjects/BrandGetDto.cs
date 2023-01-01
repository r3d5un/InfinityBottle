using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class BrandGetDto
{
    [Key]
    public int BrandId { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("FK_Brands_Distilleries")]
    public int CompanyId { get; set; }
}
