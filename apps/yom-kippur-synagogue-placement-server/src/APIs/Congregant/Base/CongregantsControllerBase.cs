using Microsoft.AspNetCore.Mvc;
using YomKippurSynagoguePlacement.APIs;
using YomKippurSynagoguePlacement.APIs.Common;
using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.APIs.Errors;

namespace YomKippurSynagoguePlacement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CongregantsControllerBase : ControllerBase
{
    protected readonly ICongregantsService _service;

    public CongregantsControllerBase(ICongregantsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Congregant
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Congregant>> CreateCongregant(CongregantCreateInput input)
    {
        var congregant = await _service.CreateCongregant(input);

        return CreatedAtAction(nameof(Congregant), new { id = congregant.Id }, congregant);
    }

    /// <summary>
    /// Delete one Congregant
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCongregant(
        [FromRoute()] CongregantWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCongregant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Congregants
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Congregant>>> Congregants(
        [FromQuery()] CongregantFindManyArgs filter
    )
    {
        return Ok(await _service.Congregants(filter));
    }

    /// <summary>
    /// Meta data about Congregant records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CongregantsMeta(
        [FromQuery()] CongregantFindManyArgs filter
    )
    {
        return Ok(await _service.CongregantsMeta(filter));
    }

    /// <summary>
    /// Get one Congregant
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Congregant>> Congregant(
        [FromRoute()] CongregantWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Congregant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Congregant
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCongregant(
        [FromRoute()] CongregantWhereUniqueInput uniqueId,
        [FromQuery()] CongregantUpdateInput congregantUpdateDto
    )
    {
        try
        {
            await _service.UpdateCongregant(uniqueId, congregantUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
