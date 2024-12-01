using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PortofolioBackend.Services.Interface;
using PortofolioBackend.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAdminAuthService _authService;

    public AuthController(IAdminAuthService authService)
    {
        _authService = authService;
    }

    // POST: api/Auth/Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var token = await _authService.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        return Ok(new { token });
    }
}