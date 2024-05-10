using AutoMapper;
using EventPlanningAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using EventTask = EventPlanningAPI.Domain.Models.Task;
using EventPlanningAPI.Domain.Services;

namespace EventPlanningAPI.Controllers
{
    [Route("/api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskResource>> ListAsync()
        {
            var tasks = await this.taskService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<EventTask>, IEnumerable<TaskResource>>(tasks);
            return resources;
        }
    }
}