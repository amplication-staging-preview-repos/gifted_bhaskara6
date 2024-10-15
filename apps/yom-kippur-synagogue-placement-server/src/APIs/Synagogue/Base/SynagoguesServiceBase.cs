using Microsoft.EntityFrameworkCore;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;
using YomKippurSynagoguePlacement.APIs.Extensions;
using YomKippurSynagoguePlacement.Infrastructure;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs;

public abstract class SynagoguesServiceBase : ISynagoguesService
{
    protected readonly YomKippurSynagoguePlacementDbContext _context;

    public SynagoguesServiceBase(YomKippurSynagoguePlacementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Synagogue
    /// </summary>
    public async Task<Synagogue> CreateSynagogue(SynagogueCreateInput createDto)
    {
        var synagogue = new SynagogueDbModel
        {
            Address = createDto.Address,
            Capacity = createDto.Capacity,
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            synagogue.Id = createDto.Id;
        }
        if (createDto.Reservations != null)
        {
            synagogue.Reservations = await _context
                .Reservations.Where(reservation =>
                    createDto.Reservations.Select(t => t.Id).Contains(reservation.Id)
                )
                .ToListAsync();
        }

        _context.Synagogues.Add(synagogue);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SynagogueDbModel>(synagogue.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Synagogue
    /// </summary>
    public async Task DeleteSynagogue(SynagogueWhereUniqueInput uniqueId)
    {
        var synagogue = await _context.Synagogues.FindAsync(uniqueId.Id);
        if (synagogue == null)
        {
            throw new NotFoundException();
        }

        _context.Synagogues.Remove(synagogue);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Synagogues
    /// </summary>
    public async Task<List<Synagogue>> Synagogues(SynagogueFindManyArgs findManyArgs)
    {
        var synagogues = await _context
            .Synagogues.Include(x => x.Reservations)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return synagogues.ConvertAll(synagogue => synagogue.ToDto());
    }

    /// <summary>
    /// Meta data about Synagogue records
    /// </summary>
    public async Task<MetadataDto> SynagoguesMeta(SynagogueFindManyArgs findManyArgs)
    {
        var count = await _context.Synagogues.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Synagogue
    /// </summary>
    public async Task<Synagogue> Synagogue(SynagogueWhereUniqueInput uniqueId)
    {
        var synagogues = await this.Synagogues(
            new SynagogueFindManyArgs { Where = new SynagogueWhereInput { Id = uniqueId.Id } }
        );
        var synagogue = synagogues.FirstOrDefault();
        if (synagogue == null)
        {
            throw new NotFoundException();
        }

        return synagogue;
    }

    /// <summary>
    /// Update one Synagogue
    /// </summary>
    public async Task UpdateSynagogue(
        SynagogueWhereUniqueInput uniqueId,
        SynagogueUpdateInput updateDto
    )
    {
        var synagogue = updateDto.ToModel(uniqueId);

        if (updateDto.Reservations != null)
        {
            synagogue.Reservations = await _context
                .Reservations.Where(reservation =>
                    updateDto.Reservations.Select(t => t).Contains(reservation.Id)
                )
                .ToListAsync();
        }

        _context.Entry(synagogue).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Synagogues.Any(e => e.Id == synagogue.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Reservations records to Synagogue
    /// </summary>
    public async Task ConnectReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Synagogues.Include(x => x.Reservations)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reservations.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Reservations);

        foreach (var child in childrenToConnect)
        {
            parent.Reservations.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Reservations records from Synagogue
    /// </summary>
    public async Task DisconnectReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Synagogues.Include(x => x.Reservations)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reservations.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Reservations?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Reservations records for Synagogue
    /// </summary>
    public async Task<List<Reservation>> FindReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationFindManyArgs synagogueFindManyArgs
    )
    {
        var reservations = await _context
            .Reservations.Where(m => m.SynagogueId == uniqueId.Id)
            .ApplyWhere(synagogueFindManyArgs.Where)
            .ApplySkip(synagogueFindManyArgs.Skip)
            .ApplyTake(synagogueFindManyArgs.Take)
            .ApplyOrderBy(synagogueFindManyArgs.SortBy)
            .ToListAsync();

        return reservations.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Reservations records for Synagogue
    /// </summary>
    public async Task UpdateReservations(
        SynagogueWhereUniqueInput uniqueId,
        ReservationWhereUniqueInput[] childrenIds
    )
    {
        var synagogue = await _context
            .Synagogues.Include(t => t.Reservations)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (synagogue == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Reservations.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        synagogue.Reservations = children;
        await _context.SaveChangesAsync();
    }
}
