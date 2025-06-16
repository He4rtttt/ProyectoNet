namespace TuApp.Domain.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(int userId, string username, string email, List<string> roles);
}