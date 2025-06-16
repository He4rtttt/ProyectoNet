namespace TuApp.Application.Features.Dtos;

public record AuthResponseDto
{
    public string Token { get; init; } = string.Empty;
    public DateTime Expiration { get; init; }
    public string UserId { get; init; } = string.Empty;
    public List<string> Roles { get; set; }
}