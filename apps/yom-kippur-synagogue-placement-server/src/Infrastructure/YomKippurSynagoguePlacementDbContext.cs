using Microsoft.EntityFrameworkCore;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.Infrastructure;

public class YomKippurSynagoguePlacementDbContext : DbContext
{
    public YomKippurSynagoguePlacementDbContext(
        DbContextOptions<YomKippurSynagoguePlacementDbContext> options
    )
        : base(options) { }

    public DbSet<ReservationDbModel> Reservations { get; set; }

    public DbSet<SynagogueDbModel> Synagogues { get; set; }

    public DbSet<CongregantDbModel> Congregants { get; set; }

    public DbSet<LocationDbModel> Locations { get; set; }
}
