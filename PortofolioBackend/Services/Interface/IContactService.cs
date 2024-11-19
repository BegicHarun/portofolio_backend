using System.Collections.Generic;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact> GetContactByIdAsync(int id);
    Task AddContactAsync(Contact contact);
    Task DeleteContactAsync(int id);
}