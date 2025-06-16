using AutoMapper;
using MediatR;
using TuApp.Application.Features.UserRoles.Dtos;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.UserRoles.Queries.GetById;

public class GetUserRoleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetUserRoleByIdQuery, UserRoleDto>
{

    public async Task<UserRoleDto> Handle(
        GetUserRoleByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var userRole = await unitOfWork.UserRoles.GetByIdAsync(request.UserId, request.RoleId);
        if (userRole == null)
            throw new KeyNotFoundException("Relación User-Role no encontrada");

        return mapper.Map<UserRoleDto>(userRole);
    }
}