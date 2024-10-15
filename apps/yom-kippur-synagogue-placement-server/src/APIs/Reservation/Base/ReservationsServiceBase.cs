using Microsoft.EntityFrameworkCore;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;
using YomKippurSynagoguePlacement.APIs.Extensions;
using YomKippurSynagoguePlacement.Infrastructure;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs;

public abstract class ReservationsServiceBase : IReservationsService
{
    protected readonly YomKippurSynagoguePlacementDbContext _context;

    public ReservationsServiceBase(YomKippurSynagoguePlacementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Reservation
    /// </summary>
    public async Task<Reservation> CreateReservation(ReservationCreateInput createDto)
    {
        var reservation = new ReservationDbModel
        {
            Congregrant = createDto.Congregrant,
            CreatedAt = createDto.CreatedAt,
            Date = createDto.Date,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            reservation.Id = createDto.Id;
        }
        if (createDto.Synagogue != null)
        {
            reservation.Synagogue = await _context
                .Synagogues.Where(synagogue => createDto.Synagogue.Id == synagogue.Id)
                .FirstOrDefaultAsync();
        }

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ReservationDbModel>(reservation.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Reservation
    /// </summary>
    public async Task DeleteReservation(ReservationWhereUniqueInput uniqueId)
    {
        var reservation = await _context.Reservations.FindAsync(uniqueId.Id);
        if (reservation == null)
        {
            throw new NotFoundException();
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Reservations
    /// </summary>
    public async Task<List<Reservation>> Reservations(ReservationFindManyArgs findManyArgs)
    {
        var reservations = await _context
            .Reservations.Include(x => x.Synagogue)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return reservations.ConvertAll(reservation => reservation.ToDto());
    }

    /// <summary>
    /// Meta data about Reservation records
    /// </summary>
    public async Task<MetadataDto> ReservationsMeta(ReservationFindManyArgs findManyArgs)
    {
        var count = await _context.Reservations.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Reservation
    /// </summary>
    public async Task<Reservation> Reservation(ReservationWhereUniqueInput uniqueId)
    {
        var reservations = await this.Reservations(
            new ReservationFindManyArgs { Where = new ReservationWhereInput { Id = uniqueId.Id } }
        );
        var reservation = reservations.FirstOrDefault();
        if (reservation == null)
        {
            throw new NotFoundException();
        }

        return reservation;
    }

    /// <summary>
    /// Update one Reservation
    /// </summary>
    public async Task UpdateReservation(
        ReservationWhereUniqueInput uniqueId,
        ReservationUpdateInput updateDto
    )
    {
        var reservation = updateDto.ToModel(uniqueId);

        if (updateDto.Synagogue != null)
        {
            reservation.Synagogue = await _context
                .Synagogues.Where(synagogue => updateDto.Synagogue == synagogue.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(reservation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reservations.Any(e => e.Id == reservation.Id))
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
    /// Get a Synagogue record for Reservation
    /// </summary>
    public async Task<Synagogue> GetSynagogue(ReservationWhereUniqueInput uniqueId)
    {
        var reservation = await _context
            .Reservations.Where(reservation => reservation.Id == uniqueId.Id)
            .Include(reservation => reservation.Synagogue)
            .FirstOrDefaultAsync();
        if (reservation == null)
        {
            throw new NotFoundException();
        }
        return reservation.Synagogue.ToDto();
    }
}
