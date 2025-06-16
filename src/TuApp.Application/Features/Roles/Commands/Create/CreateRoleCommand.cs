using MediatR;

namespace TuApp.Application.Features.Roles.Commands.Create;

public record CreateRoleCommand : IRequest<int>
{
    public string RoleName { get; init; } = null!;
}