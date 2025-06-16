namespace TuApp.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUsersRepository Users { get; }
    IRolesRepository Roles { get; }
    ITicketsRepository Tickets { get; }
    IUserRolesRepository UserRoles { get; }
    IResponsesRepository Responses { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
