using AutoMapper;
using MediatR;
using TuApp.Application.Features.UserRoles.Dtos;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.UserRoles.Queries.GetAll;

public class GetAllUserRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllUserRolesQuery, IEnumerable<UserRoleDto>>
{
    

    public async Task<IEnumerable<UserRoleDto>> Handle(
        GetAllUserRolesQuery request, 
        CancellationToken cancellationToken)
    {
        var userRoles = await unitOfWork.UserRoles.GetAllAsync();
        return mapper.Map<IEnumerable<UserRoleDto>>(userRoles);
    }
}