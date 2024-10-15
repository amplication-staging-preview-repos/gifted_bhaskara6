using Microsoft.AspNetCore.Mvc;

namespace YomKippurSynagoguePlacement.APIs;

[ApiController()]
public class LocationsController : LocationsControllerBase
{
    public LocationsController(ILocationsService service)
        : base(service) { }
}
