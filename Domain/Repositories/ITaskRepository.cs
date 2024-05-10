using EventTask = EventPlanningAPI.Domain.Models.Task;

namespace Supermarket.API.Domain.Repositories
{
    public interface ITaskRepository
    {
         Task<IEnumerable<EventTask>> ListAsync();
    }
}