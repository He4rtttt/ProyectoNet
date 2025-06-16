using AutoMapper;
using MediatR;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.Roles.Commands.Create;

public class CreateRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateRoleCommand, int>
{
    

    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = mapper.Map<Role>(request);
        
        await unitOfWork.Roles.AddAsync(role);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return role.RoleId;
    }
}