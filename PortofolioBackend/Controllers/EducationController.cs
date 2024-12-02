using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PortofolioBackend.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class EducationController : ControllerBase
{
    private readonly IEducationService _service;

    public EducationController(IEducationService service)
    {
        _service = service;
    }

    // GET: api/Education
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Education>>> GetAllEducation()
    {
        return Ok(await _service.GetAllEducationAsync());
    }

    // GET: api/Education/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Education>> GetEducationById(int id)
    {
        var education = await _service.GetEducationByIdAsync(id);
        if (education == null)
        {
            return NotFound();
        }
        return Ok(education);
    }

    // POST: api/Education
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateEducation(Education education)
    {
        await _service.AddEducationAsync(education);
        return CreatedAtAction(nameof(GetEducationById), new { id = education.Id }, education);
    }

    // PUT: api/Education/{id}
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEducation(int id, Education education)
    {
        if (id != education.Id)
        {
            return BadRequest("Education ID mismatch");
        }

        await _service.UpdateEducationAsync(education);
        return NoContent();
    }

    // DELETE: api/Education/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEducation(int id)
    {
        await _service.DeleteEducationAsync(id);
        return NoContent();
    }
}