using MediatR;
using TuApp.Application.Features.Responses.Dtos;

namespace TuApp.Application.Features.Responses.Queries.GetById;

public record GetResponseByIdQuery : IRequest<ResponseDetailDto>
{
    public int ResponseId { get; init; }
}