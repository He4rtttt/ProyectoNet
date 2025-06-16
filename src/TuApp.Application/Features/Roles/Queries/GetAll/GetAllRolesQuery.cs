using MediatR;
using TuApp.Application.Features.Roles.Dtos;

namespace TuApp.Application.Features.Roles.Queries.GetAll;

public record GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>;