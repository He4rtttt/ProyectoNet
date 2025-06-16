using MediatR;

namespace TuApp.Application.Features.Responses.Commands.Update;

public record UpdateResponseCommand : IRequest<Unit>
{
    public int ResponseId { get; init; }
    public int TicketId { get; init; }
    public string? Message { get; init; }
}