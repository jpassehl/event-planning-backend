using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanningAPI.Controllers
{
    [Route("/api/[controller]")]
    public class EventIdeaController : Controller
    {
        private IEventIdeaService eventIdeaService;
        
        public EventIdeaController(IEventIdeaService eventIdeaService)
        {
             this.eventIdeaService = eventIdeaService;   
        }

        [HttpGet]
        public async Task<IEnumerable<EventIdea>> GetAllAsync()
        {
            var eventIdeas = await eventIdeaService.ListAsync();
            return eventIdeas;
        }
    }
}