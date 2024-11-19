using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _repository;

    public SkillService(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        return await _repository.GetAllSkillsAsync();
    }

    public async Task<Skill> GetSkillByIdAsync(int id)
    {
        return await _repository.GetSkillByIdAsync(id);
    }

    public async Task AddSkillAsync(Skill skill)
    {
        await _repository.AddSkillAsync(skill);
    }

    public async Task UpdateSkillAsync(Skill skill)
    {
        await _repository.UpdateSkillAsync(skill);
    }

    public async Task DeleteSkillAsync(int id)
    {
        await _repository.DeleteSkillAsync(id);
    }
}