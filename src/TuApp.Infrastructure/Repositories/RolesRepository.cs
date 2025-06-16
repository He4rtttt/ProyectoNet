using Microsoft.EntityFrameworkCore;
using TuApp.Application.Interfaces;
using TuApp.Domain.Entities;
using TuApp.Infrastructure.Data;

namespace TuApp.Infrastructure.Repositories;

public class RolesRepository : IRolesRepository
{
    private readonly ApplicationDbContext _context;
    public RolesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Role> GetByIdAsync(int roleId)
    {
        return await _context.Roles.FindAsync(roleId);
    }
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }
    public async Task AddAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
    }
    public void Update(Role role)
    {
        _context.Roles.Update(role);
    }
    public void Delete(Role role)
    {
        _context.Roles.Remove(role);
    }
    public async Task<bool> ExistsAsync(int roleId)
    {
        return await _context.Roles.AnyAsync(r => r.RoleId == roleId);
    }
    
    public async Task<Role?> GetByIdWithUsersAsync(int roleId)
    {
        return await _context.Roles
            .Include(r => r.UserRoles) // Carga los UserRoles
            .ThenInclude(ur => ur.User) // Carga los Users relacionados
            .FirstOrDefaultAsync(r => r.RoleId == roleId);
    }
        
}