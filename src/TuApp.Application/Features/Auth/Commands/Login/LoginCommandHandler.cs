using System.Globalization;
using MediatR;
using Microsoft.Extensions.Configuration;
using TuApp.Application.Features.Dtos;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;
using TuApp.Domain.Interfaces;
using TuApp.Domain.Services;

namespace TuApp.Application.Auth.Commands.Login;

public class LoginCommandHandler(IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator, IConfiguration configuration, IUserRolesRepository userRolesRepository) : IRequestHandler<LoginCommand, AuthResponseDto>
{
    public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByEmailAsync(request.Email);
        if (user == null) throw new UnauthorizedAccessException("Credenciales invalidas");

        if (!passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
            throw new UnauthorizedAccessException("Credenciales invalidas");

        var roles = await userRolesRepository.GetRolesByUserIdAsync(user.UserId);
        
        var roleNames = roles.Select(r => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(r.RoleName.ToLower())).ToList();
        
        var token = jwtTokenGenerator.GenerateToken(
            userId: user.UserId,
            username: user.Username,    
            email: user.Email,
            roles: roleNames);


        return new AuthResponseDto
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(
                configuration.GetValue<double>("Jwt:ExpiryInMinutes", 60)),
            UserId = user.UserId.ToString(),
            Roles = roleNames
        };
    }
}