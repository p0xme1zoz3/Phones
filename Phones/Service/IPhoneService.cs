using Phones.Model;
using Phones.Dto;

namespace Phones.Services;

public interface IPhoneService
{
    public Task<List<Phone>> AllPhones();
    public Task<Phone?> GetPhone(int id);
    public Task<Phone?> UpdatePhone(PhoneUpdateDto phoneDto);
    public Task<Phone?> AddPhone(PhoneAddDto phoneDto);
    public Task<Phone?> DeletePhone(int id);
}