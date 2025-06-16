using MediatR;
using TuApp.Application.Features.Tickets.Dtos;

namespace TuApp.Application.Features.Tickets.Queries.GetAll;

public record GetAllTicketsQuery : IRequest<IEnumerable<TicketDto>>;