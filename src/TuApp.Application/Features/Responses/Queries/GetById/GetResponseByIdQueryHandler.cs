using AutoMapper;
using MediatR;
using TuApp.Application.Features.Responses.Dtos;
using TuApp.Application.Interfaces;

namespace TuApp.Application.Features.Responses.Queries.GetById;

public class GetResponseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper): IRequestHandler<GetResponseByIdQuery, ResponseDetailDto>
{
    public async Task<ResponseDetailDto> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await unitOfWork.Responses.GetByIdAsync(request.ResponseId);
        if (response == null)
            throw new KeyNotFoundException("Response no encontrada");

        return mapper.Map<ResponseDetailDto>(response);
    }
}