using EventPlanningAPI.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace EventPlanningAPI.Domain.Repositories
{
    public interface IEventIdeaRepository
    {
        Task<IEnumerable<EventIdea>> ListAsync();
        Task AddAsync(EventIdea eventIdea);
        Task<EventIdea> FindByIdAsync(int id);
	    void Update(EventIdea eventIdea);
        void Remove(EventIdea eventIdea);
    }
}