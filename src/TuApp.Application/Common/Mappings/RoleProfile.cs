using AutoMapper;
using TuApp.Application.Features.Roles.Commands.Create;
using TuApp.Application.Features.Roles.Dtos;
using TuApp.Domain.Entities;

namespace TuApp.Application.Common.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<CreateRoleCommand, Role>();
        CreateMap<Role, RoleDto>();
        CreateMap<Role, RoleDetailDto>()
            .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => new UserRolesDto
            {
                UserId = ur.UserId,
                UserName = ur.User.Username
            })));
    }
}