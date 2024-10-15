using YomKippurSynagoguePlacement.Core.Enums;

namespace YomKippurSynagoguePlacement.APIs.Dtos;

public class ReservationCreateInput
{
    public string? Congregrant { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? Id { get; set; }

    public StatusEnum? Status { get; set; }

    public Synagogue? Synagogue { get; set; }

    public DateTime UpdatedAt { get; set; }
}
