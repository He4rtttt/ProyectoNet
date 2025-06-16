namespace TuApp.Application.Features.User.Dtos;

public record UserDto
{
    public int Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime? CreatedAt { get; init; }
}