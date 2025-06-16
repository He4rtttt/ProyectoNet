using MediatR;

namespace TuApp.Application.Features.User.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<int>
{
    public int UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string? Email { get; init; }
}