using TuApp.Infrastructure.Data;

namespace TuApp.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;




public class ResponsesRepository:IResponsesRepository
{
    private readonly ApplicationDbContext _context;
    public ResponsesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Response> GetByIdAsync(int responseId)
    {
        return await _context.Responses.FindAsync(responseId);
    }
    public async Task<IEnumerable<Response>> GetAllAsync()
    {
        return await _context.Responses.ToListAsync();
    }
    public async Task AddAsync(Response response)
    {
        await _context.Responses.AddAsync(response);
    }
    public void Update(Response response)
    {
        _context.Responses.Update(response);
    }
    public void Delete(Response response)
    {
        _context.Responses.Remove(response);
    }
        
}
