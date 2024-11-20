using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }

    // GET: api/Project
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
    {
        return Ok(await _service.GetAllProjectsAsync());
    }

    // GET: api/Project/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProjectById(int id)
    {
        var project = await _service.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    // POST: api/Project
    [HttpPost]
    public async Task<ActionResult> CreateProject(Project project)
    {
        await _service.AddProjectAsync(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
    }

    // PUT: api/Project/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(int id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest("Project ID mismatch");
        }

        await _service.UpdateProjectAsync(project);
        return NoContent();
    }

    // DELETE: api/Project/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        await _service.DeleteProjectAsync(id);
        return NoContent();
    }
    [HttpGet("Paginated")]
    public async Task<ActionResult> GetProjectsPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var (projects, totalRecords) = await _service.GetProjectsPaginatedAsync(pageNumber, pageSize);

        var response = new
        {
            TotalRecords = totalRecords,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize),
            Data = projects
        };

        return Ok(response);
    }
}