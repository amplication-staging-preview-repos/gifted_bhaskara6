using Microsoft.AspNetCore.Mvc;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ReservationFindManyArgs : FindManyInput<Reservation, ReservationWhereInput> { }
