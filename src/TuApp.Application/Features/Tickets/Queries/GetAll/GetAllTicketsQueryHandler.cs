using AutoMapper;
using MediatR;
using TuApp.Application.Features.Tickets.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Tickets.Queries.GetAll;

public class GetAllTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
{
    public async Task<IEnumerable<TicketDto>> Handle(
        GetAllTicketsQuery request, 
        CancellationToken cancellationToken)
    {
        var tickets = await unitOfWork.Tickets.GetAllAsync();
        return mapper.Map<IEnumerable<TicketDto>>(tickets);
    }
}