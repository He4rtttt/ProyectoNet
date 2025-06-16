using TuApp.Domain.Entities;

namespace TuApp.Application.Interfaces
{
    public interface IResponsesRepository
    {
        Task<Response> GetByIdAsync(int responseId);
        Task<IEnumerable<Response>> GetAllAsync();
        Task AddAsync(Response response);
        void Update(Response response);
        void Delete(Response response);
    }
 
}


