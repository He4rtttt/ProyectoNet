using MediatR;
using TuApp.Application.Features.UserRoles.Dtos;

namespace TuApp.Application.Features.UserRoles.Queries.GetById;

public record GetUserRoleByIdQuery : IRequest<UserRoleDto>
{
    public int UserId { get; init; }
    public int RoleId { get; init; }
}