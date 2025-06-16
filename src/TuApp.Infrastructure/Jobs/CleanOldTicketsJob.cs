using Microsoft.Extensions.Logging;
using TuApp.Application.Interfaces;
using TuApp.Application.Jobs;


namespace TuApp.Infrastructure.Jobs;

public class CleanOldTicketsJob : ICleanOldTicketsJob
{
    
    private readonly ILogger<CleanOldTicketsJob> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CleanOldTicketsJob(ILogger<CleanOldTicketsJob> logger, IUnitOfWork unitOfWork)
    {
        
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-30);
        var oldClosedTickets = await _unitOfWork.Tickets.GetClosedTicketsBeforeAsync(cutoffDate);

        _logger.LogInformation("🔍 Se encontraron {Count} tickets cerrados antes de {Date}", oldClosedTickets.Count(), cutoffDate);

        foreach (var ticket in oldClosedTickets)
        {
            _unitOfWork.Tickets.Delete(ticket);
        }

        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        _logger.LogInformation("🧹 Limpieza de tickets antiguos completada.");
    }
}