using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _repository.GetAllContactsAsync();
    }

    public async Task<Contact> GetContactByIdAsync(int id)
    {
        return await _repository.GetContactByIdAsync(id);
    }

    public async Task AddContactAsync(Contact contact)
    {
        await _repository.AddContactAsync(contact);
    }

    public async Task DeleteContactAsync(int id)
    {
        await _repository.DeleteContactAsync(id);
    }
}