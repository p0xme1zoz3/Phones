using Phones.Model;
using Phones.Dto;

namespace Phones.Services;

public interface IPhoneService
{
    public Task<List<Phone>> AllPhones();
    public Task<Phone?> GetPhone(int id);
    public Task<Phone?> UpdatePhone(Phone phone);
    public Task<Phone?> AddPhone(PhoneDto phoneDto);
    public Task<Phone?> DeletePhone(int id);
}