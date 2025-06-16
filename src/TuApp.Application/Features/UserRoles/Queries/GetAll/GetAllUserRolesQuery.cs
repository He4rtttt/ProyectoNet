using MediatR;
using TuApp.Application.Features.UserRoles.Dtos;

namespace TuApp.Application.Features.UserRoles.Queries.GetAll;

public record GetAllUserRolesQuery : IRequest<IEnumerable<UserRoleDto>>;