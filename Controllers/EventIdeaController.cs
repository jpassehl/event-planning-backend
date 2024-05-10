using AutoMapper;
using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Services;
using EventPlanningAPI.Extensions;
using EventPlanningAPI.Resources;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanningAPI.Controllers
{
    [Route("/api/[controller]")]
    public class EventIdeaController : Controller
    {
        private IEventIdeaService eventIdeaService;
        private readonly IMapper mapper;

        public EventIdeaController(IEventIdeaService eventIdeaService, IMapper mapper)
        {
            this.eventIdeaService = eventIdeaService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventIdeaResource>> GetAllAsync()
        {
            var eventIdeas = await eventIdeaService.ListAsync();
            var resources = mapper.Map<IEnumerable<EventIdea>, IEnumerable<EventIdeaResource>>(
                eventIdeas
            );

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEventIdeaResource resource)
        {
            /*
            Note about Task<IActionResult> Response Type:
            Methods present in controller classes are called actions, and they have this 
            signature because we can return more than one possible result after the application executes the action. 
            
            [FromBody] attribute tells ASP.NET Core to parse the request body data into our new resource class. It means that 
            when a JSON containing the category name is sent to our application, the framework will automatically parse it to our new class.
             */
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var eventIdea = mapper.Map<SaveEventIdeaResource, EventIdea>(resource);
            var result = await eventIdeaService.SaveAsync(eventIdea);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var eventIdeaResource = mapper.Map<EventIdea, EventIdeaResource>(result.EventIdea);
            return Ok(eventIdeaResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEventIdeaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var eventIdea = this.mapper.Map<SaveEventIdeaResource, EventIdea>(resource);
            var result = await this.eventIdeaService.UpdateAsync(id, eventIdea);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventIdeaResource = this.mapper.Map<EventIdea, EventIdeaResource>(result.EventIdea);
            return Ok(eventIdeaResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await this.eventIdeaService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var eventIdeaResource = this.mapper.Map<EventIdea, EventIdeaResource>(result.EventIdea);
            return Ok(eventIdeaResource);
        }
    }
}
