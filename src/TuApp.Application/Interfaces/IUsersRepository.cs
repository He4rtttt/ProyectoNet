using TuApp.Domain.Entities;

public interface IUsersRepository
{
    Task<User> GetByIdAsync(int userId);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    void Update(User user);
    void Delete(User user);

    Task<User?> GetByEmailAsync(string email);

    // métodos específicos si tienes
}