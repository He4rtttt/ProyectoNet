using TuApp.Domain.Entities;

namespace TuApp.Application.Interfaces
{
    public interface ITicketsRepository
    {
        Task<Ticket> GetByIdAsync(int ticketId);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);
        // métodos específicos si tienes
        
        Task<IEnumerable<Ticket>> GetTicketsOlderThan(DateTime cutoffDate); 
        
        Task<IEnumerable<Ticket>> GetClosedTicketsBeforeAsync(DateTime cutoffDate);
    }
}