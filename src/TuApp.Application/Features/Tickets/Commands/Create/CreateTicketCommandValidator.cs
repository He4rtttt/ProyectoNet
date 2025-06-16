using FluentValidation;

namespace TuApp.Application.Features.Tickets.Commands.Create;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.Status).NotEmpty().MaximumLength(20);
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}