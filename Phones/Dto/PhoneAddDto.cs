namespace Phones.Dto;

public class PhoneAddDto
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly Date { get; set; }
    public decimal Price { get; set; }
}