using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task AddProjectAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProjectAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ProjectExistsAsync(int id)
    {
        return await _context.Projects.AnyAsync(p => p.Id == id);
    }
}