using AutoMapper;
using TuApp.Application.Features.Responses.Commands.Create;
using TuApp.Application.Features.Responses.Dtos;
using TuApp.Domain.Entities;

namespace TuApp.Application.Common.Mappings;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<CreateResponseCommand, Response>();
        CreateMap<Response, ResponseDto>();
        CreateMap<Response, ResponseDetailDto>()
            .ForMember(dest => dest.TicketTitle, opt => opt.MapFrom(src => src.Ticket.Title))
            .ForMember(dest => dest.ResponderName, opt => opt.MapFrom(src => src.Responder.Username));
    }
}