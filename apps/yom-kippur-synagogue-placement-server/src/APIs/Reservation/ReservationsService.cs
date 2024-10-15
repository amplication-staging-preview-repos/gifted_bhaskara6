using YomKippurSynagoguePlacement.Infrastructure;

namespace YomKippurSynagoguePlacement.APIs;

public class ReservationsService : ReservationsServiceBase
{
    public ReservationsService(YomKippurSynagoguePlacementDbContext context)
        : base(context) { }
}
