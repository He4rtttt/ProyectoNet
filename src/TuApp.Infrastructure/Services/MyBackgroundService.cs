using Microsoft.Extensions.Logging;
using TuApp.Application.Interfaces;
using TuApp.Domain.Interfaces;
using TuApp.Domain.Entities;

namespace TuApp.Infrastructure.Services
{
    public class MyBackgroundService : IMyBackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MyBackgroundService(
            ILogger<MyBackgroundService> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessTicketAsync(int ticketId)
        {
            try
            {
                var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId);
                if (ticket != null && ticket.Status != "Cerrado")
                {
                    _logger.LogInformation($"Procesando ticket {ticketId}: {ticket.Title}");
                    
                    // Simular trabajo de procesamiento
                    await Task.Delay(1000);
                    
                    // Actualizar estado del ticket
                    ticket.Status = "En Proceso";
                    _unitOfWork.Tickets.Update(ticket);
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                    
                    _logger.LogInformation($"Ticket {ticketId} marcado como 'En Proceso'");
                }
                else if (ticket != null)
                {
                    _logger.LogInformation($"Ticket {ticketId} ya está cerrado, no se procesará");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error procesando ticket {ticketId}");
                throw;
            }
        }

        public async Task CleanupOldData()
        {
            try
            {
                var cutoffDate = DateTime.UtcNow.AddDays(-30);
                var oldTickets = await _unitOfWork.Tickets
                    .GetTicketsOlderThan(cutoffDate);
                
                int deletedCount = 0;
                
                foreach (var ticket in oldTickets)
                {
                    if (ticket.Status == "Cerrado")
                    {
                        _unitOfWork.Tickets.Delete(ticket);
                        deletedCount++;
                    }
                }
                
                if (deletedCount > 0)
                {
                    await _unitOfWork.SaveChangesAsync(CancellationToken.None);
                    _logger.LogInformation($"Eliminados {deletedCount} tickets cerrados y antiguos");
                }
                else
                {
                    _logger.LogInformation("No se encontraron tickets cerrados antiguos para eliminar");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la limpieza de tickets antiguos");
                throw;
            }
        }
    }
}