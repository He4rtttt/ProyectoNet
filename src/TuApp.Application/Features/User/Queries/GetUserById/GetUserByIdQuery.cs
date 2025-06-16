using MediatR;
using TuApp.Application.Features.User.Dtos;

namespace TuApp.Application.Features.User.Queries.GetUserById;

public record GetUserByIdQuery : IRequest<UserDto>
{
    public int UserId { get; init; }
}