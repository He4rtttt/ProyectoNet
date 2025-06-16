using AutoMapper;
using TuApp.Application.Features.User.Commands.UpdateUser;
using TuApp.Application.Features.User.Dtos;
using TuApp.Application.Users.Commands;
using TuApp.Domain.Entities;


namespace TuApp.Application.Common.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Mapeo de CreateUserCommand a User
        CreateMap<RegisterCommand, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        
        // mapeo para update user
        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
        
        //mapeo para listar usuarios
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

    }
}