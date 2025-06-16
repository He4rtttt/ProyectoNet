using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Responses.Commands.Delete;

public class DeleteResponseCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteResponseCommand, Unit>
{
    public async Task<Unit> Handle(DeleteResponseCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar la respuesta existente
        var existingResponse = await unitOfWork.Responses.GetByIdAsync(request.ResponseId);
        if (existingResponse == null)
            throw new KeyNotFoundException("Respuesta no encontrada");

        // 2. Eliminar la respuesta
        unitOfWork.Responses.Delete(existingResponse);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}