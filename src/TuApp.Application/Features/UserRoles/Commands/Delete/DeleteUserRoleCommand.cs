using MediatR;

namespace TuApp.Application.Features.UserRoles.Commands.Delete;

public record DeleteUserRoleCommand : IRequest<Unit>
{
    public int UserId { get; init; }
    public int RoleId { get; init; }
}