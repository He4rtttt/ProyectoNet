using MediatR;

namespace TuApp.Application.Features.Tickets.Commands.Update;

public record UpdateTicketCommand : IRequest<Unit>
{
    public int TicketId { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Status { get; init; }
}