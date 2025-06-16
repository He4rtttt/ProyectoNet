using MediatR;
using TuApp.Application.Features.Roles.Dtos;

namespace TuApp.Application.Features.Roles.Queries.GetById;

public record GetRoleByIdQuery : IRequest<RoleDetailDto>
{
    public int RoleId { get; init; }
}