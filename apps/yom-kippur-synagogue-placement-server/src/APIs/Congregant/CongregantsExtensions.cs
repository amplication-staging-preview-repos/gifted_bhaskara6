using YomKippurSynagoguePlacement.APIs.Dtos;
using YomKippurSynagoguePlacement.Infrastructure.Models;

namespace YomKippurSynagoguePlacement.APIs.Extensions;

public static class CongregantsExtensions
{
    public static Congregant ToDto(this CongregantDbModel model)
    {
        return new Congregant
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CongregantDbModel ToModel(
        this CongregantUpdateInput updateDto,
        CongregantWhereUniqueInput uniqueId
    )
    {
        var congregant = new CongregantDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            PhoneNumber = updateDto.PhoneNumber
        };

        if (updateDto.CreatedAt != null)
        {
            congregant.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            congregant.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return congregant;
    }
}
