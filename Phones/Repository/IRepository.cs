using Phones.Model;

namespace Phones.Repository;

public interface IRepository
{
    public List<Phone> AllPhones();
    public Phone GetPhone(int id);
    public Phone UpdatePhone(Phone phone);
    public Phone DeletePhone(int id);
    public Phone AddPhone(Phone phone);
}