using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public interface IExperienceService
{
    Task<IEnumerable<Experience>> GetAllExperiencesAsync();
    Task<Experience> GetExperienceByIdAsync(int id);
    Task AddExperienceAsync(Experience experience);
    Task UpdateExperienceAsync(Experience experience);
    Task DeleteExperienceAsync(int id);
}