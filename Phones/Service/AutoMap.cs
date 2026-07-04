using Phones.Dto;
using Phones.Model;

namespace Phones.Services;

public class AutoMap
{
    public static Phone TranslateCreate(PhoneAddDto phoneDto)
    {
        return new Phone{Brand = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
    }
    public static Phone TranslateUpdate(PhoneUpdateDto phoneDto)
    {
        return new Phone{Id = phoneDto.Id, Brand = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
    }
}