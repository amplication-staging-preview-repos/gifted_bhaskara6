using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs.Extensions;

public static class SynagoguesExtensions
{
    public static Synagogue ToDto(this SynagogueDbModel model)
    {
        return new Synagogue
        {
            Address = model.Address,
            Capacity = model.Capacity,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            Reservations = model.Reservations?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SynagogueDbModel ToModel(
        this SynagogueUpdateInput updateDto,
        SynagogueWhereUniqueInput uniqueId
    )
    {
        var synagogue = new SynagogueDbModel
        {
            Id = uniqueId.Id,
            Address = updateDto.Address,
            Capacity = updateDto.Capacity,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            synagogue.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            synagogue.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return synagogue;
    }
}
