using EventTask = EventPlanningAPI.Domain.Models.Task;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Repositories;
using EventPlanningAPI.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventTask>> ListAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
    }
}