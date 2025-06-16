using MediatR;
using TuApp.Application.Features.User.Dtos;

namespace TuApp.Application.Features.User.Queries.GetAll;

public record GetAllUserQuery : IRequest<IEnumerable<UserDto>>;