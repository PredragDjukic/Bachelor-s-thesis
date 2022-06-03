namespace Diplomski.BLL.DTOs.PaymentDTOs;

public class PaymentCreateDto
{
    public int TrainerId { get; set; }
    public int ExerciserId { get; set; }
    public string CustomerId { get; set; }
    public decimal Price { get; set; }
}