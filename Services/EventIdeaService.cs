using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Domain.Services;
using EventPlanningAPI.Domain.Services.Communication;
using Supermarket.API.Persistence.Repositories;

namespace EventPlanningAPI.Services
{
    public class EventIdeaService : IEventIdeaService
    {
        private IEventIdeaRepository eventIdeaRepository;
        private IUnitOfWork unitOfWork;

        public EventIdeaService(IEventIdeaRepository eventIdeaRepository, IUnitOfWork unitOfWork)
        {
            this.eventIdeaRepository = eventIdeaRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EventIdea>> ListAsync()
        {
            return await eventIdeaRepository.ListAsync();
        }

        public async Task<EventIdeaResponse> SaveAsync(EventIdea eventIdea)
        {
            try
            {
                await this.eventIdeaRepository.AddAsync(eventIdea);
                await this.unitOfWork.CompleteAsync();

                return new EventIdeaResponse(eventIdea);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EventIdeaResponse(
                    $"An error occurred when saving the Event Idea: {ex.Message}"
                );
            }
        }

        public async Task<EventIdeaResponse> UpdateAsync(int id, EventIdea eventIdea)
        {
            var existingEventIdea = await eventIdeaRepository.FindByIdAsync(id);

            if (existingEventIdea == null)
            {
                return new EventIdeaResponse("Event Idea not found.");
            }

            existingEventIdea.Name = eventIdea.Name;
            existingEventIdea.Description = eventIdea.Description;
            existingEventIdea.ImgUrl = eventIdea.ImgUrl;

            try
            {
                eventIdeaRepository.Update(existingEventIdea);
                await this.unitOfWork.CompleteAsync();

                return new EventIdeaResponse(existingEventIdea);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EventIdeaResponse(
                    $"An error occurred when updating the Event Idea: {ex.Message}"
                );
            }
        }

        public async Task<EventIdeaResponse> DeleteAsync(int id)
        {
            var existingEventIdea = await this.eventIdeaRepository.FindByIdAsync(id);

            if (existingEventIdea == null)
            {
                return new EventIdeaResponse("Event Idea not found.");
            }

            try
            {
                this.eventIdeaRepository.Remove(existingEventIdea);
                await this.unitOfWork.CompleteAsync();

                return new EventIdeaResponse(existingEventIdea);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EventIdeaResponse(
                    $"An error occurred when deleting the Event Idea: {ex.Message}"
                );
            }
        }
        
        public async Task<EventIdeaResponse> GetEventIdeaAsync(int id)
        {
            try
            {
                var existingEventIdea = await eventIdeaRepository.FindByIdAsync(id);

                if (existingEventIdea == null)
                {
                    return new EventIdeaResponse("Event Idea not found.");
                }

                return new EventIdeaResponse(existingEventIdea);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EventIdeaResponse(
                    $"An error occurred when retrieving the Event Idea: {ex.Message}"
                );
            }

        }
    }
}
