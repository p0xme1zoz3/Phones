using System.ComponentModel.DataAnnotations;

namespace Phones.Dto;

public class PhoneAddDto
{
    [Required(ErrorMessage = "A brand is neccessary")]
    [StringLength(50, MinimumLength = 1,ErrorMessage = "Length from 1 to 50 characters")]
    public string Brand { get; set; }
    
    [Required(ErrorMessage = "A model is neccessary")]
    [StringLength(50, MinimumLength = 1,ErrorMessage = "Length from 1 to 50 characters")]
    public string Model { get; set; }
    
    public DateOnly? Date { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Price from 0 to ...")]
    public decimal Price { get; set; }
}