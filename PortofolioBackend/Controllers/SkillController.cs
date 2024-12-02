using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PortofolioBackend.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _service;

    public SkillController(ISkillService service)
    {
        _service = service;
    }

    // GET: api/Skill
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
    {
        return Ok(await _service.GetAllSkillsAsync());
    }

    // GET: api/Skill/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Skill>> GetSkillById(int id)
    {
        var skill = await _service.GetSkillByIdAsync(id);
        if (skill == null)
        {
            return NotFound();
        }
        return Ok(skill);
    }

    // POST: api/Skill
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> CreateSkill(Skill skill)
    {
        await _service.AddSkillAsync(skill);
        return CreatedAtAction(nameof(GetSkillById), new { id = skill.Id }, skill);
    }

    // PUT: api/Skill/{id}
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSkill(int id, Skill skill)
    {
        if (id != skill.Id)
        {
            return BadRequest("Skill ID mismatch");
        }

        await _service.UpdateSkillAsync(skill);
        return NoContent();
    }

    // DELETE: api/Skill/{id}
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        await _service.DeleteSkillAsync(id);
        return NoContent();
    }
}