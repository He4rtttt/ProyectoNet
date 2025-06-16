using TuApp.Application.Features.UserRoles.Dtos;

namespace TuApp.Application.Features.Roles.Dtos;

public record RoleDetailDto
{
    public int RoleId { get; init; }
    public string RoleName { get; init; } = null!;
    public IEnumerable<UserRoleDto> UserRoles { get; init; } = Enumerable.Empty<UserRoleDto>();
}

public record UserRolesDto
{
    public int UserId { get; init; }
    public string UserName { get; init; } = null!;
}