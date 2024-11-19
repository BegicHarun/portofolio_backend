using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class EducationRepository : IEducationRepository
{
    private readonly AppDbContext _context;

    public EducationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Education>> GetAllEducationAsync()
    {
        return await _context.Educations.ToListAsync();
    }

    public async Task<Education> GetEducationByIdAsync(int id)
    {
        return await _context.Educations.FindAsync(id);
    }

    public async Task AddEducationAsync(Education education)
    {
        await _context.Educations.AddAsync(education);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEducationAsync(Education education)
    {
        _context.Educations.Update(education);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEducationAsync(int id)
    {
        var education = await _context.Educations.FindAsync(id);
        if (education != null)
        {
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }
    }
}