using YomKippurSynagoguePlacement.Infrastructure;

namespace YomKippurSynagoguePlacement.APIs;

public class CongregantsService : CongregantsServiceBase
{
    public CongregantsService(YomKippurSynagoguePlacementDbContext context)
        : base(context) { }
}
