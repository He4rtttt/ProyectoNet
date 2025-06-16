using AutoMapper;
using MediatR;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateUserCommand, int>
{
    public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user == null) throw new KeyNotFoundException("Usuario no encontrado");

        mapper.Map(request, user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.UserId;
    }
}