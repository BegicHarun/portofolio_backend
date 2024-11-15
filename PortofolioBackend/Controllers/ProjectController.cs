using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortofolioBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            // Add the project to the database
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            // Return the created project with a 201 status code
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        // GET: api/Project/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }
    }
}