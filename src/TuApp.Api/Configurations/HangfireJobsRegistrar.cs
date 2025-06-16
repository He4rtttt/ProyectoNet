using Hangfire;
using TuApp.Application.Interfaces;
using TuApp.Application.Jobs;

namespace TuApp.API.Configurations;
public static class HangfireJobsRegistrar
{
    public static void RegisterJobs(IServiceProvider services)
    {
        var backgroundService = services.GetRequiredService<IBackgroundJobService>();

        RecurringJob.AddOrUpdate(
            "close-old-tickets",
            () => backgroundService.CloseOldTickets(),
            Cron.Daily
        );

        RecurringJob.AddOrUpdate<ITicketStatusReportService>(
            "generate-daily-ticket-status-report",
            service => service.GenerateTicketStatusReportAsync(CancellationToken.None),
            Cron.Daily(2)
        );

        RecurringJob.AddOrUpdate<ICleanOldTicketsJob>(
            "clean-old-tickets",
            job => job.ExecuteAsync(CancellationToken.None),
            Cron.Daily(3)
        );
    }
}
