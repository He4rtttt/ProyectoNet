using AutoMapper;
using MediatR;
using TuApp.Application.Features.Roles.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Roles.Queries.GetAll;

public class GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    public async Task<IEnumerable<RoleDto>> Handle(
        GetAllRolesQuery request, 
        CancellationToken cancellationToken)
    {
        var roles = await unitOfWork.Roles.GetAllAsync();
        return mapper.Map<IEnumerable<RoleDto>>(roles);
    }
}