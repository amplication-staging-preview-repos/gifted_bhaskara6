namespace YomKippurSynagoguePlacement.APIs.Dtos;

public class SynagogueCreateInput
{
    public string? Address { get; set; }

    public int? Capacity { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<Reservation>? Reservations { get; set; }

    public DateTime UpdatedAt { get; set; }
}
