using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;

namespace YomKippurSynagoguePlacement.APIs;

public interface ISynagoguesService
{
    /// <summary>
    /// Create one Synagogue
    /// </summary>
    public Task<Synagogue> CreateSynagogue(SynagogueCreateInput synagogue);

    /// <summary>
    /// Delete one Synagogue
    /// </summary>
    public Task DeleteSynagogue(SynagogueWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Synagogues
    /// </summary>
    public Task<List<Synagogue>> Synagogues(SynagogueFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Synagogue records
    /// </summary>
    public Task<MetadataDto> SynagoguesMeta(SynagogueFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Synagogue
    /// </summary>
    public Task<Synagogue> Synagogue(SynagogueWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Synagogue
    /// </summary>
    public Task UpdateSynagogue(SynagogueWhereUniqueInput uniqueId, SynagogueUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Reservations records to Synagogue
    /// </summary>
    public Task ConnectReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] reservationsId
    );

    /// <summary>
    /// Disconnect multiple Reservations records from Synagogue
    /// </summary>
    public Task DisconnectReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] reservationsId
    );

    /// <summary>
    /// Find multiple Reservations records for Synagogue
    /// </summary>
    public Task<List<Reservation>> FindReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationFindManyArgs ReservationFindManyArgs
    );

    /// <summary>
    /// Update multiple Reservations records for Synagogue
    /// </summary>
    public Task UpdateReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] reservationsId
    );
}
