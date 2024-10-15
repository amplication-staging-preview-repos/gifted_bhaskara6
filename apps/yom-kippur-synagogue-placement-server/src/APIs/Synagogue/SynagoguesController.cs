using Microsoft.AspNetCore.Mvc;

namespace YomKippurSynagoguePlacement.APIs;

[ApiController()]
public class SynagoguesController : SynagoguesControllerBase
{
    public SynagoguesController(ISynagoguesService service)
        : base(service) { }
}
