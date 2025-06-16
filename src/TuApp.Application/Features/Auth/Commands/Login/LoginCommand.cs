using MediatR;
using TuApp.Application.Features.Dtos;

namespace TuApp.Application.Auth.Commands.Login;

public record LoginCommand : IRequest<AuthResponseDto>
{
    public string Email { get; init; } = String.Empty;
    public string Password { get; init; } = String.Empty;
}