using Microsoft.AspNetCore.Mvc;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;

namespace YomKippurSynagoguePlacement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SynagoguesControllerBase : ControllerBase
{
    protected readonly ISynagoguesService _service;

    public SynagoguesControllerBase(ISynagoguesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Synagogue
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Synagogue>> CreateSynagogue(SynagogueCreateInput input)
    {
        var synagogue = await _service.CreateSynagogue(input);

        return CreatedAtAction(nameof(Synagogue), new { id = synagogue.Id }, synagogue);
    }

    /// <summary>
    /// Delete one Synagogue
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSynagogue(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteSynagogue(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Synagogues
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Synagogue>>> Synagogues(
        [FromQuery()] SynagogueFindManyArgs filter
    )
    {
        return Ok(await _service.Synagogues(filter));
    }

    /// <summary>
    /// Meta data about Synagogue records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SynagoguesMeta(
        [FromQuery()] SynagogueFindManyArgs filter
    )
    {
        return Ok(await _service.SynagoguesMeta(filter));
    }

    /// <summary>
    /// Get one Synagogue
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Synagogue>> Synagogue(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Synagogue(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Synagogue
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSynagogue(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId,
        [FromQuery()] SynagogueUpdateInput synagogueUpdateDto
    )
    {
        try
        {
            await _service.UpdateSynagogue(uniqueId, synagogueUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Reservations records to Synagogue
    /// </summary>
    [HttpPost("{Id}/reservations")]
    public async Task<ActionResult> ConnectReservations(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId,
        [FromQuery()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.ConnectReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Reservations records from Synagogue
    /// </summary>
    [HttpDelete("{Id}/reservations")]
    public async Task<ActionResult> DisconnectReservations(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId,
        [FromBody()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.DisconnectReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Reservations records for Synagogue
    /// </summary>
    [HttpGet("{Id}/reservations")]
    public async Task<ActionResult<List<Reservation>>> FindReservations(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId,
        [FromQuery()] ReservationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindReservations(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Reservations records for Synagogue
    /// </summary>
    [HttpPatch("{Id}/reservations")]
    public async Task<ActionResult> UpdateReservations(
        [FromRoute()] SynagogueWhereUniqueInput uniqueId,
        [FromBody()] ReservationWhereUniqueInput[] reservationsId
    )
    {
        try
        {
            await _service.UpdateReservations(uniqueId, reservationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
