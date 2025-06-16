namespace TuApp.Application.Features.Roles.Dtos;

public record RoleDto
{
    public int RoleId { get; init; }
    public string RoleName { get; init; } = null!;
}