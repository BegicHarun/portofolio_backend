using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PortofolioBackend.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceService _service;

    public ExperienceController(IExperienceService service)
    {
        _service = service;
    }

    // GET: api/Experience
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Experience>>> GetAllExperiences()
    {
        return Ok(await _service.GetAllExperiencesAsync());
    }

    // GET: api/Experience/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Experience>> GetExperienceById(int id)
    {
        var experience = await _service.GetExperienceByIdAsync(id);
        if (experience == null)
        {
            return NotFound();
        }
        return Ok(experience);
    }

    // POST: api/Experience
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateExperience(Experience experience)
    {
        await _service.AddExperienceAsync(experience);
        return CreatedAtAction(nameof(GetExperienceById), new { id = experience.Id }, experience);
    }

    // PUT: api/Experience/{id}
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExperience(int id, Experience experience)
    {
        if (id != experience.Id)
        {
            return BadRequest("Experience ID mismatch");
        }

        await _service.UpdateExperienceAsync(experience);
        return NoContent();
    }

    // DELETE: api/Experience/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        await _service.DeleteExperienceAsync(id);
        return NoContent();
    }
}