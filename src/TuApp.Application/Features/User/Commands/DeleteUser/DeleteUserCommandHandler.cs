using AutoMapper;
using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, int>
{
    public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user == null) throw new KeyNotFoundException("Usuario no encontrado");
        
        unitOfWork.Users.Delete(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return request.UserId;
    }
}