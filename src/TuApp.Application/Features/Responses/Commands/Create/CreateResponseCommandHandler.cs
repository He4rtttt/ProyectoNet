using AutoMapper;
using MediatR;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.Responses.Commands.Create;

public class CreateResponseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateResponseCommand, int>
{
    

    public async Task<int> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
    {
        var response = mapper.Map<Response>(request);
        response.CreatedAt = DateTime.UtcNow;
        
        await unitOfWork.Responses.AddAsync(response);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return response.ResponseId;
    }
}