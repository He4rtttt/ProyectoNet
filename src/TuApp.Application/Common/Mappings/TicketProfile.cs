using AutoMapper;
using TuApp.Application.Features.Tickets.Commands.Create;
using TuApp.Application.Features.Tickets.Dtos;
using TuApp.Domain.Entities;

namespace TuApp.Application.Common.Mappings;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<CreateTicketCommand, Ticket>();
        CreateMap<Ticket, TicketDto>();
        CreateMap<Ticket, TicketDetailDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username));
    }
}