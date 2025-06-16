using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Roles.Commands.Delete;

public class DeleteRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoleCommand, Unit>
{
    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new KeyNotFoundException($"Role con el ID {request.RoleId} no encontrado.");
        }

        unitOfWork.Roles.Delete(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}