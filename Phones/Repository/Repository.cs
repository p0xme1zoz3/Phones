using Phones.Model;
using Microsoft.EntityFrameworkCore;

namespace Phones.Repository;

public class Repository : IRepository
{
    public List<Phone> phones = new ()
    {
        new Phone(1,"Nokia","3410",new DateOnly(2005,10,1),0),
        new Phone(2,"Nokia","1600",new DateOnly(2007,6,1),0),
        new Phone(3,"Nokia","E-71",new DateOnly(2011,5,1),0)
    };
    
    public List<Phone> AllPhones() => phones;

    private ApplicationContext _db;

    public Repository(ApplicationContext db) 
    { 
        _db = db; 
    } 
    
    public List<Phone> AllPhonesDb() => _db.Phones.ToList();
    public Phone GetPhoneDb(int id) 
    {
        Phone phone = _db.Phones.FirstOrDefault(u => u.Id == id);
        if (phone == null) return new Phone();
        return phone;
    }    
        
    public Phone GetPhone(int id)
    {
        Phone phone = phones.FirstOrDefault(u => u.Id == id);
        if (phone == null)
            return new Phone();
        return phone;
    }

    public Phone UpdatePhone(Phone phone)
    {
        Phone phoneItem = phones.FirstOrDefault(u => u.Id == phone.Id);
        if (phoneItem == null) return new Phone();
        
        foreach (var item in phones) {
            if (item.Id == phone.Id) {
                item.Brand = phone.Brand;
                item.Model = phone.Model;
                item.Date = phone.Date;
                item.Price = phone.Price;

            }
        }
        
        phoneItem = phones.FirstOrDefault(u => u.Id == phone.Id);
        return phoneItem;
    }

    public Phone UpdatePhoneDb(Phone phone)
    {
        Phone phoneItem = _db.Phones.FirstOrDefault(u => u.Id == phone.Id);
        if (phoneItem == null) return new Phone();
        phoneItem.Brand = phone.Brand;
        phoneItem.Model = phone.Model;
        phoneItem.Date = phone.Date;
        phoneItem.Price = phone.Price;
        _db.SaveChanges();
        return phoneItem;
    }
    
    public Phone DeletePhone(int id)
    {
        Phone phone = phones.FirstOrDefault(u => u.Id == id);
        if (phone == null) return new Phone();
        phones.Remove(phone);
        return phone;
    }

    public Phone AddPhone(Phone phone)
    {
        int id = phones[phones.Count-1].Id+1; 
        phone.Id = id;
        phones.Add(phone);
        return phone;
    }
    public Phone AddPhoneDb(Phone phone)
    {
        _db.Phones.Add(phone);
        _db.SaveChanges();
        return phone;
    }
    
    public Phone DeletePhoneDb(int id)
    {
        Phone phone = _db.Phones.FirstOrDefault(u => u.Id == id);
        if (phone == null) return new Phone();
        _db.Phones.Remove(phone);
        _db.SaveChanges();
        return phone;
    }
}