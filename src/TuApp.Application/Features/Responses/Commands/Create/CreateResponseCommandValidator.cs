using FluentValidation;

namespace TuApp.Application.Features.Responses.Commands.Create;

public class CreateResponseCommandValidator : AbstractValidator<CreateResponseCommand>
{
    public CreateResponseCommandValidator()
    {
        RuleFor(x => x.TicketId).GreaterThan(0);
        RuleFor(x => x.ResponderId).GreaterThan(0);
        RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
    }
}