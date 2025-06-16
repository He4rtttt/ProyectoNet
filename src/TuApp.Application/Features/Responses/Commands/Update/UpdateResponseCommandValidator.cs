using FluentValidation;

namespace TuApp.Application.Features.Responses.Commands.Update;

public class UpdateResponseCommandValidator : AbstractValidator<UpdateResponseCommand>
{
    public UpdateResponseCommandValidator()
    {
        RuleFor(x => x.ResponseId).GreaterThan(0).WithMessage("El ID de la respuesta debe ser mayor que 0.");
        RuleFor(x => x.TicketId).GreaterThan(0).WithMessage("El ID del ticket debe ser mayor que 0.");
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("El mensaje no puede estar vacío.")
            .MaximumLength(500).WithMessage("El mensaje no puede exceder los 500 caracteres.");
    }
}