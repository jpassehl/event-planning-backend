using EventTask = EventPlanningAPI.Domain.Models.Task;
using EventPlanningAPI.Domain.Services;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
    
        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<IEnumerable<EventTask>> ListAsync()
        {
            return await this.taskRepository.ListAsync();
        }
    }
}