
using TuApp.Application.Interfaces;

namespace TuApp.Infrastructure.Services;

public class BackgroundJobService : IBackgroundJobService
{
    public void SendEmailNotification(string toEmail, string subject, string message)
    {
       
        Console.WriteLine($"Enviando correo a {toEmail}: {subject}");
    }

    public void LogActivity(string action, int userId)
    {
        Console.WriteLine($"Log: Usuario {userId} realizó la acción {action} a las {DateTime.Now}");
    }

    public void CloseOldTickets()
    {
        Console.WriteLine("Cerrando tickets antiguos...");
        
    }
}