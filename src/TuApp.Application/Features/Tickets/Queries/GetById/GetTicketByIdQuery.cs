using MediatR;
using TuApp.Application.Features.Tickets.Dtos;

namespace TuApp.Application.Features.Tickets.Queries.GetById;

public record GetTicketByIdQuery : IRequest<TicketDetailDto>
{
    public int TicketId { get; init; }
}