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

    public Task<Phone?> UpdatePhone(Phone phone)
    {
        var res = _repo.UpdatePhone(phone);
        return res;
    }

    public Task<Phone?> AddPhone(PhoneDto phoneDto)
    {
        var res = _repo.AddPhone(phoneDto);
        return res;
    }

    public Task<Phone?> DeletePhone(int id)
    {
        var res = _repo.DeletePhone(id);
        return res;
    }
}