namespace Phones.Dto;

public class PhoneUpdateDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly Date { get; set; }
    public decimal Price { get; set; }
}