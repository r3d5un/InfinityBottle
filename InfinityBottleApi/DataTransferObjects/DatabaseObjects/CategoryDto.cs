using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class CategoryDto
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }

    [MaxLength(50)]
    public string? SubCategory { get; set; }

    public ICollection<Whisky> Whiskies { get; set; }
}
