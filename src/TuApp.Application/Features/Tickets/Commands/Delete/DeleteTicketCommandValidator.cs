using FluentValidation;

namespace TuApp.Application.Features.Tickets.Commands.Delete;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(x => x.TicketId).GreaterThan(0).WithMessage("Ticket ID must be greater than 0.");
    }
}