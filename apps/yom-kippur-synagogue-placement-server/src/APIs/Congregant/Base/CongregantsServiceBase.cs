using Microsoft.EntityFrameworkCore;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;
using YomKippurSynagoguePlacement.APIs.Extensions;
using YomKippurSynagoguePlacement.Infrastructure;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs;

public abstract class CongregantsServiceBase : ICongregantsService
{
    protected readonly YomKippurSynagoguePlacementDbContext _context;

    public CongregantsServiceBase(YomKippurSynagoguePlacementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Congregant
    /// </summary>
    public async Task<Congregant> CreateCongregant(CongregantCreateInput createDto)
    {
        var congregant = new CongregantDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            PhoneNumber = createDto.PhoneNumber,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            congregant.Id = createDto.Id;
        }

        _context.Congregants.Add(congregant);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CongregantDbModel>(congregant.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Congregant
    /// </summary>
    public async Task DeleteCongregant(CongregantWhereUniqueInput uniqueId)
    {
        var congregant = await _context.Congregants.FindAsync(uniqueId.Id);
        if (congregant == null)
        {
            throw new NotFoundException();
        }

        _context.Congregants.Remove(congregant);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Congregants
    /// </summary>
    public async Task<List<Congregant>> Congregants(CongregantFindManyArgs findManyArgs)
    {
        var congregants = await _context
            .Congregants.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return congregants.ConvertAll(congregant => congregant.ToDto());
    }

    /// <summary>
    /// Meta data about Congregant records
    /// </summary>
    public async Task<MetadataDto> CongregantsMeta(CongregantFindManyArgs findManyArgs)
    {
        var count = await _context.Congregants.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Congregant
    /// </summary>
    public async Task<Congregant> Congregant(CongregantWhereUniqueInput uniqueId)
    {
        var congregants = await this.Congregants(
            new CongregantFindManyArgs { Where = new CongregantWhereInput { Id = uniqueId.Id } }
        );
        var congregant = congregants.FirstOrDefault();
        if (congregant == null)
        {
            throw new NotFoundException();
        }

        return congregant;
    }

    /// <summary>
    /// Update one Congregant
    /// </summary>
    public async Task UpdateCongregant(
        CongregantWhereUniqueInput uniqueId,
        CongregantUpdateInput updateDto
    )
    {
        var congregant = updateDto.ToModel(uniqueId);

        _context.Entry(congregant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Congregants.Any(e => e.Id == congregant.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
