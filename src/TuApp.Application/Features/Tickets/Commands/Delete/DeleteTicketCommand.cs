using MediatR;

namespace TuApp.Application.Features.Tickets.Commands.Delete;

public record DeleteTicketCommand : IRequest<Unit>
{
    public int TicketId { get; init; }
}