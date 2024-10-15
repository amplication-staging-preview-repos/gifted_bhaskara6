using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YomKippurSynagoguePlacement.Infrastructure.Models;

[Table("Congregants")]
public class CongregantDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(1000)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? LastName { get; set; }

    [StringLength(1000)]
    public string? PhoneNumber { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
