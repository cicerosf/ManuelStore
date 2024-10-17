namespace Authentication.API.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(string username);
    }
}