using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Domain.Services;

namespace EventPlanningAPI.Services
{
    public class EventIdeaService : IEventIdeaService
    {
        private IEventIdeaRepository eventIdeaRepository;

        public EventIdeaService(IEventIdeaRepository eventIdeaRepository)
        {
            this.eventIdeaRepository = eventIdeaRepository;
        }

        public async Task<IEnumerable<EventIdea>> ListAsync()
        {
            return await eventIdeaRepository.ListAsync();
        }
    }
}