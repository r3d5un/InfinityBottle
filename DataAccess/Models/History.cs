using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("history")]
[Index(nameof(Date))]
public class History
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("infinity_bottle_id")]
    [ForeignKey("FK_History_InfinityBottle")]
    public int InfinityBottleId { get; set; }

    [Column("whisky_id")]
    [ForeignKey("FK_History_Whisky")]
    public int WhiskyId { get; set; }

    [Required]
    [Column("amount")]
    public int Amount { get; set; }
}
