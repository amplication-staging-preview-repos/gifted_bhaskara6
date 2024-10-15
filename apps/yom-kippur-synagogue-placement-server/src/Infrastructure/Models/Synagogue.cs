using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YomKippurSynagoguePlacement.Infrastructure.Models;

[Table("Synagogues")]
public class SynagogueDbModel
{
    [StringLength(1000)]
    public string? Address { get; set; }

    [Range(-999999999, 999999999)]
    public int? Capacity { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public List<ReservationDbModel>? Reservations { get; set; } = new List<ReservationDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
