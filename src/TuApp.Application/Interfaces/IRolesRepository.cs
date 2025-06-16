using TuApp.Domain.Entities;

namespace TuApp.Application.Interfaces
{
    public interface IRolesRepository
    {
        Task<Role> GetByIdAsync(int roleId);
        Task<IEnumerable<Role>> GetAllAsync();
        Task AddAsync(Role role);
        void Update(Role role);
        void Delete(Role role);
        
        Task<bool> ExistsAsync(int roleId);
        // métodos específicos si tienes
        
        Task<Role?> GetByIdWithUsersAsync(int roleId);
    }
}