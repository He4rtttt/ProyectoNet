using AutoMapper;
using MediatR;
using TuApp.Application.Features.Responses.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Responses.Queries.GetAll;

public class GetAllResponsesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllResponsesQuery, IEnumerable<ResponseDto>>
{
    public async Task<IEnumerable<ResponseDto>> Handle(
        GetAllResponsesQuery request, 
        CancellationToken cancellationToken)
    {
        var responses = await unitOfWork.Responses.GetAllAsync();
        return mapper.Map<IEnumerable<ResponseDto>>(responses);
    }
}