using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class ExperienceService : IExperienceService
{
    private readonly IExperienceRepository _repository;

    public ExperienceService(IExperienceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        return await _repository.GetAllExperiencesAsync();
    }

    public async Task<Experience> GetExperienceByIdAsync(int id)
    {
        return await _repository.GetExperienceByIdAsync(id);
    }

    public async Task AddExperienceAsync(Experience experience)
    {
        await _repository.AddExperienceAsync(experience);
    }

    public async Task UpdateExperienceAsync(Experience experience)
    {
        await _repository.UpdateExperienceAsync(experience);
    }

    public async Task DeleteExperienceAsync(int id)
    {
        await _repository.DeleteExperienceAsync(id);
    }
}