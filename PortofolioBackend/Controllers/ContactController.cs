using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    // GET: api/Contact
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
    {
        return Ok(await _service.GetAllContactsAsync());
    }

    // GET: api/Contact/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactById(int id)
    {
        var contact = await _service.GetContactByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return Ok(contact);
    }

    // POST: api/Contact
    [HttpPost]
    public async Task<ActionResult> CreateContact(Contact contact)
    {
        await _service.AddContactAsync(contact);
        return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
    }

    // DELETE: api/Contact/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _service.DeleteContactAsync(id);
        return NoContent();
    }
}