using PortofolioBackend.Data.Models;

namespace PortofolioBackend.Repositories.Interface;

public interface IAdminRepository
{
    
    Task<Admin> GetAdminByUsernameAsync(string username);
}