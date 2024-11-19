using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _repository;

    public EducationService(IEducationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Education>> GetAllEducationAsync()
    {
        return await _repository.GetAllEducationAsync();
    }

    public async Task<Education> GetEducationByIdAsync(int id)
    {
        return await _repository.GetEducationByIdAsync(id);
    }

    public async Task AddEducationAsync(Education education)
    {
        await _repository.AddEducationAsync(education);
    }

    public async Task UpdateEducationAsync(Education education)
    {
        await _repository.UpdateEducationAsync(education);
    }

    public async Task DeleteEducationAsync(int id)
    {
        await _repository.DeleteEducationAsync(id);
    }
}