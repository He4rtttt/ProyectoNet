using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Roles.Commands.Update;

public class UpdateRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoleCommand, Unit>
{
    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await unitOfWork.Roles.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new KeyNotFoundException($"Rol con el ID {request.RoleId} no encontrado.");
        }

        role.RoleName = request.RoleName;

        unitOfWork.Roles.Update(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}