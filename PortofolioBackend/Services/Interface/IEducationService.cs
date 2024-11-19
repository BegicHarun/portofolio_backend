using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public interface IEducationService
{
    Task<IEnumerable<Education>> GetAllEducationAsync();
    Task<Education> GetEducationByIdAsync(int id);
    Task AddEducationAsync(Education education);
    Task UpdateEducationAsync(Education education);
    Task DeleteEducationAsync(int id);
}