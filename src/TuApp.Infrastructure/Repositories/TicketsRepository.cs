using Microsoft.EntityFrameworkCore;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;
using TuApp.Infrastructure.Data;

namespace TuApp.Infrastructure.Repositories;
public class TicketsRepository : ITicketsRepository
{
    private readonly ApplicationDbContext _context;
    public TicketsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Ticket> GetByIdAsync(int ticketId)
    {
        return await _context.Tickets.FindAsync(ticketId);
    }
    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await _context.Tickets.ToListAsync();
    }
    public async Task AddAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
    }
    public void Update(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
    }
    public void Delete(Ticket ticket)
    {
        _context.Tickets.Remove(ticket);
    }
    public async Task<IEnumerable<Ticket>> GetTicketsOlderThan(DateTime cutoffDate)
    {
        return await _context.Tickets
            .Where(t => t.CreatedAt < cutoffDate)
            .Include(t => t.User)
            .ToListAsync();
    }
    public async Task<IEnumerable<Ticket>> GetClosedTicketsBeforeAsync(DateTime cutoffDate)
    {
        return await _context.Tickets
            .Where(t => t.Status == "cerrado" && t.ClosedAt < cutoffDate)
            .Include(t => t.User)
            .ToListAsync();
    }
        
}
