using Phones.Dto;
using Phones.Model;

namespace Phones.Services;

public static class PhoneMapper
{
    public static Phone ToEntity(PhoneAddDto phoneDto)
    {
        return new Phone{Brand = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
    }
    public static Phone ToEntity(PhoneUpdateDto phoneDto)
    {
        return new Phone{Id = phoneDto.Id, Brand = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
    }
}