using AutoMapper;
using MediatR;
using TuApp.Application.Features.User.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user == null)
            throw new KeyNotFoundException("Usuario no encontrado");

        return mapper.Map<UserDto>(user);
    }
}