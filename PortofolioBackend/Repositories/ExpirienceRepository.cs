using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class ExperienceRepository : IExperienceRepository
{
    private readonly AppDbContext _context;

    public ExperienceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        return await _context.Experiences.ToListAsync();
    }

    public async Task<Experience> GetExperienceByIdAsync(int id)
    {
        return await _context.Experiences.FindAsync(id);
    }

    public async Task AddExperienceAsync(Experience experience)
    {
        await _context.Experiences.AddAsync(experience);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExperienceAsync(Experience experience)
    {
        _context.Experiences.Update(experience);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExperienceAsync(int id)
    {
        var experience = await _context.Experiences.FindAsync(id);
        if (experience != null)
        {
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
        }
    }
}