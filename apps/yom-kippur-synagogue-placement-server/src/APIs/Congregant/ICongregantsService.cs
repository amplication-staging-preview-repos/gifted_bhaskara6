using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;

namespace YomKippurSynagoguePlacement.APIs;

public interface ICongregantsService
{
    /// <summary>
    /// Create one Congregant
    /// </summary>
    public Task<Congregant> CreateCongregant(CongregantCreateInput congregant);

    /// <summary>
    /// Delete one Congregant
    /// </summary>
    public Task DeleteCongregant(CongregantWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Congregants
    /// </summary>
    public Task<List<Congregant>> Congregants(CongregantFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Congregant records
    /// </summary>
    public Task<MetadataDto> CongregantsMeta(CongregantFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Congregant
    /// </summary>
    public Task<Congregant> Congregant(CongregantWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Congregant
    /// </summary>
    public Task UpdateCongregant(
        CongregantWhereUniqueInput uniqueId,
        CongregantUpdateInput updateDto
    );
}
