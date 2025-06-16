
using TuApp.Domain.Entities;
using TuApp.Domain.Interfaces;
using TuApp.Domain.Services;

namespace TuApp.Application.Services;
/*
public class UserAuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserAuthService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string?> AuthenticateAsync(string email, string password)
    {
        var user = await _usersRepository.GetByEmailAsync(email);
        if (user == null) return null;

        var isValid = _passwordHasher.VerifyPassword(user.PasswordHash, password);
        if (!isValid) return null;

        return _jwtTokenGenerator.GenerateToken(user.UserId, user.Username, user.Email,
            user.Roles.Select(r => r.RoleName).ToList());
    }
}
*/