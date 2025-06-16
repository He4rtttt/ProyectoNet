namespace TuApp.Application.Interfaces;

public interface ITicketStatusReportService
{
    Task GenerateTicketStatusReportAsync(CancellationToken cancellationToken = default);
}