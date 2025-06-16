using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Tickets.Commands.Update;

public class UpdateTicketCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateTicketCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar el ticket existente
        var existingTicket = await unitOfWork.Tickets.GetByIdAsync(request.TicketId);
        if (existingTicket == null)
            throw new KeyNotFoundException("Ticket no encontrado");

        // 2. Actualizar los campos del ticket
        existingTicket.Title = request.Title;
        existingTicket.Description = request.Description;
        existingTicket.Status = request.Status;

        // 3. Guardar los cambios
        unitOfWork.Tickets.Update(existingTicket);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}