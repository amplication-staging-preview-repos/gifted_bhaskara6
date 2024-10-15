using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YomKippurSynagoguePlacement.Core.Enums;

namespace YomKippurSynagoguePlacement.Infrastructure.Models;

[Table("Reservations")]
public class ReservationDbModel
{
    [StringLength(1000)]
    public string? Congregrant { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public StatusEnum? Status { get; set; }

    public string? SynagogueId { get; set; }

    [ForeignKey(nameof(SynagogueId))]
    public SynagogueDbModel? Synagogue { get; set; } = null;

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
