namespace TuApp.Application.Features.Responses.Dtos;

public record ResponseDetailDto
{
    public int ResponseId { get; init; }
    public string Message { get; init; } = null!;
    public DateTime? CreatedAt { get; init; }
    public int TicketId { get; init; }
    public string TicketTitle { get; init; } = null!;
    public int ResponderId { get; init; }
    public string ResponderName { get; init; } = null!;
}