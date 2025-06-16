using Microsoft.EntityFrameworkCore;
using TuApp.Application.Interfaces;
using TuApp.Infrastructure.Repositories;

namespace TuApp.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UsersRepository(_context);
        Roles = new RolesRepository(_context);
        Tickets = new TicketsRepository(_context);
        UserRoles = new UserRolesRepository(_context);
        Responses = new ResponsesRepository(_context);

    }

    public IUsersRepository Users { get; private set; }
    public IRolesRepository Roles { get; private set; }
    public ITicketsRepository Tickets { get; private set; }
    public IUserRolesRepository UserRoles { get; private set; }
    public IResponsesRepository Responses { get; private set; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Error al guardar en la base de datos", ex);
        }
    }
    
    

    public void Dispose()
    {
        _context.Dispose();
    }
}
