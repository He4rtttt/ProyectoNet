using AutoMapper;
using MediatR;
using TuApp.Application.Features.User.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.User.Queries.GetAll;

public class GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(
        GetAllUserQuery request, 
        CancellationToken cancellationToken)
    {
        var users = await unitOfWork.Users.GetAllAsync();
        return mapper.Map<IEnumerable<UserDto>>(users);
    }
}