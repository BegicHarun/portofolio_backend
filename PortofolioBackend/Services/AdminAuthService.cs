using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortofolioBackend.Data.Models;
using PortofolioBackend.Repositories.Interface;
using PortofolioBackend.Services.Interface;

public class AdminAuthService : IAdminAuthService
{
    private readonly IAdminRepository _repository;
    private readonly IConfiguration _configuration;

    public AdminAuthService(IAdminRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
{
    Console.WriteLine("Starting authentication process...");

    // Fetch the admin by username
    Console.WriteLine($"Fetching admin by username: {username}");
    var admin = await _repository.GetAdminByUsernameAsync(username);

    if (admin == null)
    {
        Console.WriteLine("Admin not found in the database.");
        return null; // Authentication failed
    }

    Console.WriteLine($"Admin found: Username = {admin.Username}");
    Console.WriteLine($"Stored PasswordHash: {admin.PasswordHash}");

    // Verify password
    if (!BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
    {
        Console.WriteLine("Password verification failed. The provided password is incorrect.");
        return null; // Authentication failed
    }

    Console.WriteLine("Password verified successfully. Proceeding to generate JWT token.");

    // Generate JWT Token
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
    if (key == null || key.Length == 0)
    {
        Console.WriteLine("JWT key is missing or empty in configuration.");
        throw new Exception("JWT key not configured.");
    }
    Console.WriteLine("JWT key loaded successfully.");

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, admin.Username),
            new Claim(ClaimTypes.Role, "Admin")
        }),
        Expires = DateTime.UtcNow.AddHours(1),
        Audience = _configuration["Jwt:Audience"], // Add audience here
        Issuer = _configuration["Jwt:Issuer"],
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    Console.WriteLine($"Audience in Token Descriptor: {_configuration["Jwt:Audience"]}");

    var token = tokenHandler.CreateToken(tokenDescriptor);
    Console.WriteLine("JWT token generated successfully.");

    return tokenHandler.WriteToken(token);
}
}