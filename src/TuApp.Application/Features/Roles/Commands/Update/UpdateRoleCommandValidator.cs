using FluentValidation;

namespace TuApp.Application.Features.Roles.Commands.Update;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("El ID del rol debe ser mayor que 0");

        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("El nombre del rol es requerido")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres");
    }
}