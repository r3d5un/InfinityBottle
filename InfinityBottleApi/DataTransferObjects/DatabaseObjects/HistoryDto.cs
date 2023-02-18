using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBottleApi.DataTransferObjects.DatabaseObjects;

public class HistoryDto
{
    [Key]
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    [ForeignKey("FK_History_InfinityBottle")]
    public int InfinityBottleId { get; set; }

    [ForeignKey("FK_History_Whisky")]
    public int WhiskyId { get; set; }

    [Required]
    public int Amount { get; set; }
}
