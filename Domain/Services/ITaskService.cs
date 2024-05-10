using EventTask = EventPlanningAPI.Domain.Models.Task;

namespace EventPlanningAPI.Domain.Services
{
    public interface ITaskService
    {
         Task<IEnumerable<EventTask>> ListAsync();
    }
}