using Microsoft.AspNetCore.Mvc;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;

namespace YomKippurSynagoguePlacement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LocationsControllerBase : ControllerBase
{
    protected readonly ILocationsService _service;

    public LocationsControllerBase(ILocationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Location
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Location>> CreateLocation(LocationCreateInput input)
    {
        var location = await _service.CreateLocation(input);

        return CreatedAtAction(nameof(Location), new { id = location.Id }, location);
    }

    /// <summary>
    /// Delete one Location
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLocation([FromRoute()] LocationWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteLocation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Locations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Location>>> Locations(
        [FromQuery()] LocationFindManyArgs filter
    )
    {
        return Ok(await _service.Locations(filter));
    }

    /// <summary>
    /// Meta data about Location records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LocationsMeta(
        [FromQuery()] LocationFindManyArgs filter
    )
    {
        return Ok(await _service.LocationsMeta(filter));
    }

    /// <summary>
    /// Get one Location
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Location>> Location(
        [FromRoute()] LocationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Location(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Location
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLocation(
        [FromRoute()] LocationWhereUniqueInput uniqueId,
        [FromQuery()] LocationUpdateInput locationUpdateDto
    )
    {
        try
        {
            await _service.UpdateLocation(uniqueId, locationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
