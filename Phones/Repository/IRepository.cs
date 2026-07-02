using Phones.Model;

namespace Phones.Repository;

public interface IRepository
{
    public List<Phone> AllPhones();
    public Phone GetPhone(int id);
    public Phone UpdatePhone(Phone phone);
    public Phone DeletePhone(int id);
    public Phone AddPhone(Phone phone);
    public List<Phone> AllPhonesDb();
    public Phone GetPhoneDb(int id);
    public Phone UpdatePhoneDb(Phone phone);
    public Phone DeletePhoneDb(int id);
    public Phone AddPhoneDb(Phone phone);
}