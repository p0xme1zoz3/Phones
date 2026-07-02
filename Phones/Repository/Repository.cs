using Phones.Model;
using Microsoft.EntityFrameworkCore;

namespace Phones.Repository;

public class Repository : IRepository
{
    private ApplicationContext _db;

    public Repository(ApplicationContext db) 
    { 
        _db = db; 
    } 
    
    public List<Phone> AllPhones() => _db.Phones.ToList();
    public Phone GetPhone(int id) 
    {
        Phone phone = _db.Phones.FirstOrDefault(u => u.Id == id);
        if (phone == null) return new Phone();
        return phone;
    }    
    
    public Phone UpdatePhone(Phone phone)
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
    
    public Phone AddPhone(Phone phone)
    {
        _db.Phones.Add(phone);
        _db.SaveChanges();
        return phone;
    }
    
    public Phone DeletePhone(int id)
    {
        Phone phone = _db.Phones.FirstOrDefault(u => u.Id == id);
        if (phone == null) return new Phone();
        _db.Phones.Remove(phone);
        _db.SaveChanges();
        return phone;
    }
}