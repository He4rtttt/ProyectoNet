using MediatR;

namespace TuApp.Application.Features.UserRoles.Commands.Update;

public record UpdateUserRoleCommand : IRequest<Unit>
{
    public int UserId { get; init; }
    public int RoleId { get; init; }
    public int NewRoleId { get; init; } // Para cambiar el rol
}