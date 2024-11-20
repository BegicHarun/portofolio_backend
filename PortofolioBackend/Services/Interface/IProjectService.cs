using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task AddProjectAsync(Project project);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int id);
    Task<(IEnumerable<Project>, int)> GetProjectsPaginatedAsync(int pageNumber, int pageSize);
}