namespace TuApp.Application.Features.Tickets.Dtos;

public record TicketDto
{
    public int TicketId { get; init; }
    public string Title { get; init; } = null!;
    public string Status { get; init; } = null!;
    public DateTime? CreatedAt { get; init; }
}