using Diplomski.BLL.DTOs.PaymentDTOs;
using Stripe;

namespace Diplomski.BLL.Mappers;

internal static class PaymentMapper
{
    internal static CardReadDto ToReadDto(this Card card) => new CardReadDto()
    {
        Id = card.Id,
        Brand = card.Brand,
        Country = card.Country,
        ExpMonth = card.ExpMonth,
        ExpYear = card.ExpYear,
        LastFour = card.Last4
    };

    internal static IEnumerable<CardReadDto> ToReadDtos(this StripeList<Card> cards)
        => cards.Select(e => e.ToReadDto());
}