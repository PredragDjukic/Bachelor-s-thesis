namespace Diplomski.BLL.DTOs.PaymentDTOs;

public class CardReadDto
{
    public string Id { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Country { get; set; } = null!;
    public long ExpMonth { get; set; }
    public long ExpYear { get; set; }
    public string LastFour { get; set; } = null!;
}