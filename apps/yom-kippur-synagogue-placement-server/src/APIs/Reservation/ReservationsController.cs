using Microsoft.AspNetCore.Mvc;

namespace YomKippurSynagoguePlacement.APIs;

[ApiController()]
public class ReservationsController : ReservationsControllerBase
{
    public ReservationsController(IReservationsService service)
        : base(service) { }
}
