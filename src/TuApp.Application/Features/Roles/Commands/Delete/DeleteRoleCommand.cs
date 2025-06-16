using MediatR;

namespace TuApp.Application.Features.Roles.Commands.Delete;

public record DeleteRoleCommand : IRequest<Unit>
{
    public int RoleId { get; init; }
}