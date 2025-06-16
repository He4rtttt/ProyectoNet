namespace TuApp.Application.Features.Tickets.Dtos;

public record TicketDetailDto
{
    public int TicketId { get; init; }
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
    public string Status { get; init; } = null!;
    public DateTime? CreatedAt { get; init; }
    public DateTime? ClosedAt { get; init; }
    public int UserId { get; init; }
    public string? UserName { get; init; }
}