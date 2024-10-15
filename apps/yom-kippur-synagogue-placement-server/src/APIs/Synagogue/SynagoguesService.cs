using YomKippurSynagoguePlacement.Infrastructure;

namespace YomKippurSynagoguePlacement.APIs;

public class SynagoguesService : SynagoguesServiceBase
{
    public SynagoguesService(YomKippurSynagoguePlacementDbContext context)
        : base(context) { }
}
