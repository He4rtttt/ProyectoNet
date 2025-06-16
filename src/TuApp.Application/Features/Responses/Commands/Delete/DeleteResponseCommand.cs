using MediatR;

namespace TuApp.Application.Features.Responses.Commands.Delete;

public record DeleteResponseCommand : IRequest<Unit>
{
    public int ResponseId { get; init; }
}