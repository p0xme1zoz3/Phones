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

    public Task<List<Phone>> AllPhones()
    {
        _logger.LogInformation("Getting all phones");
        var res = _repo.AllPhones();
        _logger.LogInformation("All phones are successfully received");
        return res;
    }

    public Task<Phone?> GetPhone(int id)
    {
        _logger.LogInformation("Getting phone with id {id}", id);
        var res = _repo.GetPhone(id);
        _logger.LogInformation("Phone with id {id} is successfully received", id);
        return res;
    }

    public Task<Phone?> UpdatePhone(PhoneUpdateDto phoneDto)
    {
        _logger.LogInformation("Updating phone with id {id}", phoneDto.Id);
        Phone phone = PhoneMapper.ToEntity(phoneDto);
        var res = _repo.UpdatePhone(phone);
        _logger.LogInformation("Phone with id {id} is successfully updated", phoneDto.Id);
        return res;
    }

    public Task<Phone?> AddPhone(PhoneAddDto phoneDto)
    {
        _logger.LogInformation("Adding a new phone");
        Phone phone = PhoneMapper.ToEntity(phoneDto);
        var res = _repo.AddPhone(phone);
        _logger.LogInformation("A new phone is added");
        return res;
    }

    public Task<Phone?> DeletePhone(int id)
    {
        _logger.LogInformation("Deleting phone with id {id}", id);
        var res = _repo.DeletePhone(id);
        _logger.LogInformation("Phone with id {id} is successfully deleted", id);
        return res;
    }
}