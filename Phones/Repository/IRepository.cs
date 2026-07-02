using Phones.Model;

namespace Phones.Repository;

public interface IRepository
{
    public Task<List<Phone>> AllPhones();
    public Task<Phone> GetPhone(int id);
    public Task<Phone> UpdatePhone(Phone phone);
    public Task<Phone> AddPhone(PhoneDto phoneDto);
    public Task<Phone> DeletePhone(int id);
}