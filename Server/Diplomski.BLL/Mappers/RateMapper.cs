using Diplomski.BLL.DTOs.RateDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Mappers;

internal static class RateMapper
{
    internal static RateReadDto ToReadDto(this Rate rate) => new RateReadDto()
    {
        Rate = rate.Rate1,
        Comment = rate.Comment,
        SessionId = rate.SessionId,
        CreatedAt = rate.CreatedAt,
        UpdatedAt = rate.UpdateAt,
        Session = rate.Session.ToReadDto()
    };

    internal static IEnumerable<RateReadDto> ToReadDtos(this IEnumerable<Rate> rates) =>
        rates.Select(e => e.ToReadDto());
}