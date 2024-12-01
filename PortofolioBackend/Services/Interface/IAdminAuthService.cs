namespace PortofolioBackend.Services.Interface;

public interface IAdminAuthService
{
    Task<string> AuthenticateAsync(string username, string password);
}