using MediatR;

namespace TuApp.Application.Features.User.Commands.DeleteUser;

public record DeleteUserCommand : IRequest<int>
{
    public int UserId { get; init; }
}