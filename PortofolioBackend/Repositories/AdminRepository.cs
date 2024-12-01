using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PortofolioBackend.Data.Models;
using PortofolioBackend.Repositories.Interface;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Admin> GetAdminByUsernameAsync(string username)
    {
        return await _context.Admins.SingleOrDefaultAsync(a => a.Username == username);
    }
}