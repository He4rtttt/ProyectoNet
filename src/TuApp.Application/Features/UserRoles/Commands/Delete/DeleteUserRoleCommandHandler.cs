using MediatR;
using TuApp.Application.Features.User.Commands.DeleteUser;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.UserRoles.Commands.Delete;

public class DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserRoleCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = await unitOfWork.UserRoles.GetByIdAsync(request.UserId, request.RoleId);
        if (userRole == null)
            throw new KeyNotFoundException("Relación User-Role no encontrada");

        unitOfWork.UserRoles.Delete(userRole);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}