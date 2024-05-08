using EventPlanningAPI.Domain.Models;

namespace EventPlanningAPI.Domain.Services
{
    public interface IEventIdeaService
    {
        Task<IEnumerable<EventIdea>> ListAsync();
    }
}