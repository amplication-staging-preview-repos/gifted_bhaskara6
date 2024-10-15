using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;

namespace YomKippurSynagoguePlacement.APIs;

public interface ILocationsService
{
    /// <summary>
    /// Create one Location
    /// </summary>
    public Task<Location> CreateLocation(LocationCreateInput location);

    /// <summary>
    /// Delete one Location
    /// </summary>
    public Task DeleteLocation(LocationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Locations
    /// </summary>
    public Task<List<Location>> Locations(LocationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Location records
    /// </summary>
    public Task<MetadataDto> LocationsMeta(LocationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Location
    /// </summary>
    public Task<Location> Location(LocationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Location
    /// </summary>
    public Task UpdateLocation(LocationWhereUniqueInput uniqueId, LocationUpdateInput updateDto);
}
