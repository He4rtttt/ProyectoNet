using MediatR;

namespace TuApp.Application.Features.UserRoles.Commands.Create;

public record CreateUserRoleCommand : IRequest<int>
{
    public int UserId { get; init; }
    public int RoleId { get; init; }
    public DateTime? AssignedAt { get; init; } = DateTime.UtcNow;
}