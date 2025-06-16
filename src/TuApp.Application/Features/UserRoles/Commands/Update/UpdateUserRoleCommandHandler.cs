using MediatR;
using TuApp.Application.Features.User.Commands.UpdateUser;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.UserRoles.Commands.Update;

public class UpdateUserRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserRoleCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        // 1. Buscar la relación existente
        var existingUserRole = await unitOfWork.UserRoles.GetByIdAsync(request.UserId, request.RoleId);
        if (existingUserRole == null)
            throw new KeyNotFoundException("Relación User-Role no encontrada");

        // 2. Verificar que el nuevo rol exista
        var newRoleExists = await unitOfWork.Roles.ExistsAsync(request.NewRoleId);
        if (!newRoleExists)
            throw new KeyNotFoundException("El nuevo rol no existe");

        // 3. Eliminar la relación antigua
        unitOfWork.UserRoles.Delete(existingUserRole);

        // 4. Crear nueva relación
        var newUserRole = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.NewRoleId,
            AssignedAt = DateTime.UtcNow
        };

        await unitOfWork.UserRoles.AddAsync(newUserRole);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}