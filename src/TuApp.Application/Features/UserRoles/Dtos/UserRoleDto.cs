namespace TuApp.Application.Features.UserRoles.Dtos;

public record UserRoleDto
{
    public int UserId { get; init; }
    public int RoleId { get; init; }
    public DateTime? AssignedAt { get; init; }
    public string? UserName { get; init; }
    public string? RoleName { get; init; }
}