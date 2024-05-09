using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Services.Communication;


namespace EventPlanningAPI.Domain.Services
{
    public interface IEventIdeaService
    {
        Task<IEnumerable<EventIdea>> ListAsync();
        Task<EventIdeaResponse> SaveAsync (EventIdea eventIdea);
        Task<EventIdeaResponse> UpdateAsync(int id, EventIdea eventIdea);
        Task<EventIdeaResponse> DeleteAsync(int id);
    }
}