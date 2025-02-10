using EventTask = EventPlanningAPI.Domain.Models.Task;

namespace EventPlanningApp.API.Domain.Repositories
{
    public interface ITaskRepository
    {
         Task<IEnumerable<EventTask>> ListAsync();
    }
}