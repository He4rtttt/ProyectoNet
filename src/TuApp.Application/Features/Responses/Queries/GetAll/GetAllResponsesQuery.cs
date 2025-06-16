using MediatR;
using TuApp.Application.Features.Responses.Dtos;

namespace TuApp.Application.Features.Responses.Queries.GetAll;

public record GetAllResponsesQuery : IRequest<IEnumerable<ResponseDto>>;