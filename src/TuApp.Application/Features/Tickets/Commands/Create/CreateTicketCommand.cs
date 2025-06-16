using MediatR;

namespace TuApp.Application.Features.Tickets.Commands.Create;

public record CreateTicketCommand : IRequest<int>
{
    public int UserId { get; init; }
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
    public string Status { get; init; } = "Open";
}