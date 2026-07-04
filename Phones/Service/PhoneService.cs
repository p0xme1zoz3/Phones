using Phones.Model;
using Phones.Dto;
using Phones.Repository;

namespace Phones.Services;

public class PhoneService : IPhoneService
{
    private readonly IRepository _repo;
    private readonly ILogger<PhoneService> _logger;
    public PhoneService(IRepository repo, ILogger<PhoneService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<List<Phone>> AllPhones()
    {
        _logger.LogInformation("Getting all phones");
        var res = await _repo.AllPhones();
        
        _logger.LogInformation("All phones are successfully received");
        return res;
    }

    public async Task<Phone?> GetPhone(int id)
    {
        _logger.LogInformation("Getting phone with id {id}", id);
        var res = await _repo.GetPhone(id);
        
        if (res == null)
        {
            _logger.LogWarning("Phone with id {Id} not found", id);
            return null;
        }
            
        _logger.LogInformation("Phone with id {Id} is successfully received", id);
        return res;
    }

    public async Task<Phone?> UpdatePhone(PhoneUpdateDto phoneDto)
    {
        _logger.LogInformation("Updating phone with id {id}", phoneDto.Id);
        Phone phone = PhoneMapper.ToEntity(phoneDto);
        var res = await _repo.UpdatePhone(phone);
        if (res == null)
        {
            _logger.LogWarning("Phone with id {Id} is not found", phoneDto.Id);
            return null;
        }
        
        _logger.LogInformation("Phone with id {Id} is successfully updated", phoneDto.Id);
        return res;
    }

    public async Task<Phone?> AddPhone(PhoneAddDto phoneDto)
    {
        _logger.LogInformation("Adding a new phone");
        Phone phone = PhoneMapper.ToEntity(phoneDto);
        var res = await _repo.AddPhone(phone);
        
        if (res == null)
        {
            _logger.LogWarning("A new phone is not added");
            return null;
        }
            
        _logger.LogInformation("A new phone is added");
        return res;
    }

    public async Task<Phone?> DeletePhone(int id)
    {
        _logger.LogInformation("Deleting phone with id {Id}", id);
        var res = await _repo.DeletePhone(id);
        
        if (res == null)
        {
            _logger.LogWarning("Phone with {Id} is not deleted",id);
            return null;
        }
        
        _logger.LogInformation("Phone with id {Id} is successfully deleted", id);
        return res;
    }
}