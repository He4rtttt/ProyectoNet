namespace TuApp.Application.Features.Responses.Dtos;

public record ResponseDto
{
    public int ResponseId { get; init; }
    public string Message { get; init; } = null!;
    public DateTime? CreatedAt { get; init; }
    public int TicketId { get; init; }
    public int ResponderId { get; init; }
}