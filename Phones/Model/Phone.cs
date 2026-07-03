namespace Phones.Model;

public class Phone
{
    public Phone()
    {
        
    }
    public Phone(int id, string brand, string model, DateOnly date, decimal price)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Date = date;
        Price = price;
    }
    
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public DateOnly Date { get; set; }
    public decimal Price { get; set; }
}