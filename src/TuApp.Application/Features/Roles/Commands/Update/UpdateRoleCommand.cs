using MediatR;

namespace TuApp.Application.Features.Roles.Commands.Update;

public record UpdateRoleCommand : IRequest<Unit>
{
    public int RoleId { get; init; }
    public string RoleName { get; init; } = null!;
}