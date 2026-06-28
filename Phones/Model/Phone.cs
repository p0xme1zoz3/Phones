namespace Phones.Model;

public class Phone
{
    public Phone()
    {
        
    }
    public Phone(int id, string brand, string model, DateOnly year, decimal price)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }
        
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly Year { get; set; }
    public decimal Price { get; set; }
}