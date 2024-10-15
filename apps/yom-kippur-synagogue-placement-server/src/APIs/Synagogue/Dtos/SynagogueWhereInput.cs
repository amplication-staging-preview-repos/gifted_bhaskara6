namespace YomKippurSynagoguePlacement.APIs.Dtos;

public class SynagogueWhereInput
{
    public string? Address { get; set; }

    public int? Capacity { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<string>? Reservations { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
