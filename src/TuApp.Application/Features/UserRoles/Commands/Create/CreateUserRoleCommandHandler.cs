using AutoMapper;
using MediatR;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.UserRoles.Commands.Create;

public class CreateUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateUserRoleCommand, int>
{
    public async Task<int> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = mapper.Map<UserRole>(request);
        await unitOfWork.UserRoles.AddAsync(userRole);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return userRole.UserId;
    }
}