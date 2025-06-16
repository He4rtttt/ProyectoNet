using System.Threading.Tasks;

namespace TuApp.Application.Interfaces
{
    public interface IMyBackgroundService
    {
        /// <summary>
        /// Procesa un ticket específico de forma asíncrona
        /// </summary>
        /// <param name="ticketId">ID del ticket a procesar</param>
        Task ProcessTicketAsync(int ticketId);

        /// <summary>
        /// Limpia tickets cerrados antiguos del sistema
        /// </summary>
        Task CleanupOldData();
    }
}