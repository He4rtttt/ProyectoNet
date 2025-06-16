using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Tickets.Commands.Delete;

public class DeleteTicketCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteTicketCommand, Unit>
{   
    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await unitOfWork.Tickets.GetByIdAsync(request.TicketId);
        if (ticket == null)
            throw new KeyNotFoundException("Ticket not found");

        unitOfWork.Tickets.Delete(ticket);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}