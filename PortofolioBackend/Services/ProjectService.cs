using System.Collections.Generic;
using System.Threading.Tasks;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _repository.GetAllProjectsAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        return await _repository.GetProjectByIdAsync(id);
    }

    public async Task AddProjectAsync(Project project)
    {
        await _repository.AddProjectAsync(project);
    }

    public async Task UpdateProjectAsync(Project project)
    {
        await _repository.UpdateProjectAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        await _repository.DeleteProjectAsync(id);
    }
}