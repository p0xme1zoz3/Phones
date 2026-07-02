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

    public async Task<List<Phone>> AllPhones()
    {   
        return await _db.Phones.ToListAsync();
    }
    public async Task<Phone> GetPhone(int id) 
    {
        var phone = await _db.Phones.FirstOrDefaultAsync(u => u.Id == id);
        if (phone == null) return new Phone();
        return phone;
    }    
    
    public async Task<Phone> UpdatePhone(Phone phone)
    {
        var phoneItem = await _db.Phones.FirstOrDefaultAsync(u => u.Id == phone.Id);
        if (phoneItem == null) return new Phone();
        phoneItem.Brand = phone.Brand;
        phoneItem.Model = phone.Model;
        phoneItem.Date = phone.Date;
        phoneItem.Price = phone.Price;
        await _db.SaveChangesAsync();
        return phoneItem;
    }
    
    public async Task<Phone> AddPhone(PhoneDto phoneDto)
    {
        Phone phone = new Phone
        {
            Brand = phoneDto.Brand,
            Model = phoneDto.Model,
            Date = phoneDto.Date,
            Price = phoneDto.Price
        };
        await _db.Phones.AddAsync(phone);
        await _db.SaveChangesAsync();
        return phone;
    }
    
    public async Task<Phone> DeletePhone(int id)
    {
        var phone = await _db.Phones.FirstOrDefaultAsync(u => u.Id == id);
        if (phone == null) return new Phone();
        _db.Phones.Remove(phone);
        await _db.SaveChangesAsync();
        return phone;
    }
}