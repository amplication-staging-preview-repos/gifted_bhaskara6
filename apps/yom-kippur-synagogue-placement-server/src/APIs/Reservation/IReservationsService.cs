using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;

namespace YomKippurSynagoguePlacement.APIs;

public interface IReservationsService
{
    /// <summary>
    /// Create one Reservation
    /// </summary>
    public Task<Reservation> CreateReservation(ReservationCreateInput reservation);

    /// <summary>
    /// Delete one Reservation
    /// </summary>
    public Task DeleteReservation(ReservationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Reservations
    /// </summary>
    public Task<List<Reservation>> Reservations(ReservationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Reservation records
    /// </summary>
    public Task<MetadataDto> ReservationsMeta(ReservationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Reservation
    /// </summary>
    public Task<Reservation> Reservation(ReservationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Reservation
    /// </summary>
    public Task UpdateReservation(
        ReservationWhereUniqueInput uniqueId,
        ReservationUpdateInput updateDto
    );

    /// <summary>
    /// Get a Synagogue record for Reservation
    /// </summary>
    public Task<Synagogue> GetSynagogue(ReservationWhereUniqueInput uniqueId);
}
