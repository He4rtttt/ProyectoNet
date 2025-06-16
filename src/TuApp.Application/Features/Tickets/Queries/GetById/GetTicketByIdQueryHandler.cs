using AutoMapper;
using MediatR;
using TuApp.Application.Features.Tickets.Dtos;
using TuApp.Application.Features.Tickets.Queries.GetById;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Tickets.Queries.GetAll;

public class GetTicketByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetTicketByIdQuery, TicketDetailDto>
{
    public async Task<TicketDetailDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await unitOfWork.Tickets.GetByIdAsync(request.TicketId);
        if (ticket == null)
            throw new KeyNotFoundException("Ticket no enontrado");

        return mapper.Map<TicketDetailDto>(ticket);
    }
}