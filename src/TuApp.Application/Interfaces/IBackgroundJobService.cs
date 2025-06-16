
namespace TuApp.Application.Interfaces;

public interface IBackgroundJobService
{
    void SendEmailNotification(string toEmail, string subject, string message);
    void LogActivity(string action, int userId);
    void CloseOldTickets();
}