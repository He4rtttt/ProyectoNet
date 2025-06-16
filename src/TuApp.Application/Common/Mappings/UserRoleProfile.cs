using AutoMapper;
using TuApp.Application.Features.UserRoles.Commands.Create;
using TuApp.Application.Features.UserRoles.Dtos;
using TuApp.Domain.Entities;

namespace TuApp.Application.Common.Mappings;

public class UserRoleProfile : Profile
{
    public UserRoleProfile()
    {
        CreateMap<CreateUserRoleCommand, UserRole>();

        CreateMap<UserRole, UserRoleDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
    }
}