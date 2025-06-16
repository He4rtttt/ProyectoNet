using AutoMapper;
using Hangfire;
using MediatR;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Application.Features.Tickets.Commands.Create;

public class CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IBackgroundJobService backgroundJobService) : IRequestHandler<CreateTicketCommand, int>
{

    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = mapper.Map<Ticket>(request);
        ticket.CreatedAt = DateTime.UtcNow;
        
        await unitOfWork.Tickets.AddAsync(ticket);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        // Encolar el envío de notificación por correo
        BackgroundJob.Enqueue(() => backgroundJobService.SendEmailNotification("soporte@midominio.com", "Nuevo Ticket", $"Ticket {ticket.Title} creado."));

        // Encolar registro de actividad
        BackgroundJob.Enqueue(() => backgroundJobService.LogActivity("Creó un ticket", ticket.UserId));
        
        return ticket.TicketId;
    }
}