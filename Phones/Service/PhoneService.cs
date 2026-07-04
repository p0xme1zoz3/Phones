using Phones.Model;
using Phones.Dto;
using Phones.Repository;

namespace Phones.Services;

public class PhoneService : IPhoneService
{
    private readonly IRepository _repo;
    public PhoneService(IRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Phone>> AllPhones()
    {
        var res = _repo.AllPhones();
        return res;
    }

    public Task<Phone?> GetPhone(int id)
    {
        var res = _repo.GetPhone(id);
        return res;
    }

    public Task<Phone?> UpdatePhone(PhoneUpdateDto phoneDto)
    {
        Phone phone = new Phone{Id = phoneDto.Id, Brand = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
        var res = _repo.UpdatePhone(phone);
        return res;
    }

    public Task<Phone?> AddPhone(PhoneAddDto phoneDto)
    {
        Phone phone = new Phone{Brand  = phoneDto.Brand, Model = phoneDto.Model, Price = phoneDto.Price};
        var res = _repo.AddPhone(phone);
        return res;
    }

    public Task<Phone?> DeletePhone(int id)
    {
        var res = _repo.DeletePhone(id);
        return res;
    }
}