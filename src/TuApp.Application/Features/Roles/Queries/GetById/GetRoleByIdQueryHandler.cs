using AutoMapper;
using MediatR;
using TuApp.Application.Features.Roles.Dtos;
using TuApp.Application.Features.UserRoles.Dtos;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.Roles.Queries.GetById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDetailDto>
{
    private readonly IRolesRepository _rolesRepository;

    public GetRoleByIdQueryHandler(IRolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }

    public async Task<RoleDetailDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _rolesRepository.GetByIdWithUsersAsync(request.RoleId);
        
        if (role == null)
        {
            throw new KeyNotFoundException($"Role with ID {request.RoleId} not found.");
        }

        return new RoleDetailDto
        {
            RoleId = role.RoleId,
            RoleName = role.RoleName,
            UserRoles = role.UserRoles.Select(ur => new UserRoleDto
            {
                UserId = ur.UserId,
                RoleId = ur.RoleId,
                UserName = ur.User?.Username // Asegúrate de cargar User
            }).ToList()
        };
    }
}