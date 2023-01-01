using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class CategoryPostDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Region { get; set; }

    [MaxLength(50)]
    public string SubCategory { get; set; }
}
