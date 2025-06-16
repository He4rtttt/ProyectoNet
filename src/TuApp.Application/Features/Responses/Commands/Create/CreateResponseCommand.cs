using MediatR;

namespace TuApp.Application.Features.Responses.Commands.Create;

public record CreateResponseCommand : IRequest<int>
{
    public int TicketId { get; init; }
    public int ResponderId { get; init; }
    public string Message { get; init; } = null!;
}