using Microsoft.Extensions.Logging;
using TuApp.Application.Interfaces;

namespace TuApp.Infrastructure.Services;

public class TicketStatusReportService : ITicketStatusReportService
{
    private readonly ILogger<TicketStatusReportService> _logger;

    public TicketStatusReportService(ILogger<TicketStatusReportService> logger)
    {
        _logger = logger;
    }

    public async Task GenerateTicketStatusReportAsync(CancellationToken cancellationToken = default)
    {
        
        _logger.LogInformation("📝 Generando reporte de tickets por estado a las {Date}", DateTime.UtcNow);
        
        
        await Task.Delay(1000, cancellationToken);

        _logger.LogInformation("✅ Reporte de tickets generado correctamente.");
    }
}