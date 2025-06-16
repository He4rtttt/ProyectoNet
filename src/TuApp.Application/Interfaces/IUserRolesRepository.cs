using TuApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TuApp.Application.Interfaces
{
    public interface IUserRolesRepository
    {
        // Operaciones básicas CRUD
        Task<UserRole> GetByIdAsync(int userId, int roleId);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task AddAsync(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(UserRole userRole);
        
        // Consultas específicas
        Task<IEnumerable<UserRole>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserRole>> GetByRoleIdAsync(int roleId);
        
        // Métodos específicos para roles
        Task<List<Role>> GetRolesByUserIdAsync(int userId);
        Task<bool> UserHasRoleAsync(int userId, string roleName);
        Task AssignRoleToUserAsync(int userId, int roleId);
        Task RemoveRoleFromUserAsync(int userId, int roleId);
    }
}