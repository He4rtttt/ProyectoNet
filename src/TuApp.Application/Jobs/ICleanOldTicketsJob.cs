namespace TuApp.Application.Jobs;

public interface ICleanOldTicketsJob
{
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}