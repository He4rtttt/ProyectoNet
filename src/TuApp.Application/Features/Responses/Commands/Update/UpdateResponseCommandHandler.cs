using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Responses.Commands.Update;

public class UpdateResponseCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateResponseCommand, Unit>
{
    public async Task<Unit> Handle(UpdateResponseCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar la respuesta existente
        var existingResponse = await unitOfWork.Responses.GetByIdAsync(request.ResponseId);
        if (existingResponse == null)
            throw new KeyNotFoundException("Respuesta no encontrada");

        // 2. Actualizar los campos de la respuesta
        existingResponse.TicketId = request.TicketId;
        existingResponse.Message = request.Message;

        // 3. Guardar los cambios
        unitOfWork.Responses.Update(existingResponse);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}