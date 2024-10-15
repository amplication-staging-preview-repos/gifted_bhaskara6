using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs.Extensions;

public static class LocationsExtensions
{
    public static Location ToDto(this LocationDbModel model)
    {
        return new Location
        {
            City = model.City,
            Country = model.Country,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            State = model.State,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LocationDbModel ToModel(
        this LocationUpdateInput updateDto,
        LocationWhereUniqueInput uniqueId
    )
    {
        var location = new LocationDbModel
        {
            Id = uniqueId.Id,
            City = updateDto.City,
            Country = updateDto.Country,
            State = updateDto.State
        };

        if (updateDto.CreatedAt != null)
        {
            location.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            location.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return location;
    }
}
