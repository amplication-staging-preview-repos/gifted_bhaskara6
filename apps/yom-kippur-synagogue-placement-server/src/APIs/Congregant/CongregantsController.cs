using Microsoft.AspNetCore.Mvc;

namespace YomKippurSynagoguePlacement.APIs;

[ApiController()]
public class CongregantsController : CongregantsControllerBase
{
    public CongregantsController(ICongregantsService service)
        : base(service) { }
}
