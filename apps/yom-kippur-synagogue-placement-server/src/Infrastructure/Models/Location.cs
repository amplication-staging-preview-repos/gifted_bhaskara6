using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YomKippurSynagoguePlacement.Infrastructure.Models;

[Table("Locations")]
public class LocationDbModel
{
    [StringLength(1000)]
    public string? City { get; set; }

    [StringLength(1000)]
    public string? Country { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? State { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
