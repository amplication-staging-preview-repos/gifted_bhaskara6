using YomKippurSynagoguePlacement.Infrastructure;

namespace YomKippurSynagoguePlacement.APIs;

public class LocationsService : LocationsServiceBase
{
    public LocationsService(YomKippurSynagoguePlacementDbContext context)
        : base(context) { }
}
