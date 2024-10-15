using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs.Extensions;

public static class ReservationsExtensions
{
    public static Reservation ToDto(this ReservationDbModel model)
    {
        return new Reservation
        {
            Congregrant = model.Congregrant,
            CreatedAt = model.CreatedAt,
            Date = model.Date,
            Id = model.Id,
            Status = model.Status,
            Synagogue = model.SynagogueId,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ReservationDbModel ToModel(
        this ReservationUpdateInput updateDto,
        ReservationWhereUniqueInput uniqueId
    )
    {
        var reservation = new ReservationDbModel
        {
            Id = uniqueId.Id,
            Congregrant = updateDto.Congregrant,
            Date = updateDto.Date,
            Status = updateDto.Status
        };

        if (updateDto.CreatedAt != null)
        {
            reservation.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Synagogue != null)
        {
            reservation.SynagogueId = updateDto.Synagogue;
        }
        if (updateDto.UpdatedAt != null)
        {
            reservation.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return reservation;
    }
}
