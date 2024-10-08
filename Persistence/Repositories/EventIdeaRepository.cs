using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Task = System.Threading.Tasks.Task;

namespace Supermarket.API.Persistence.Repositories
{
    public class EventIdeaRepository : BaseRepository, IEventIdeaRepository
    {
        public EventIdeaRepository(AppDbContext context)
            : base(context) { }

        public async Task<IEnumerable<EventIdea>> ListAsync()
        {
            return await _context.EventIdeas.Include( e => e.Tasks).ToListAsync();

        }

        public async Task AddAsync(EventIdea eventIdea)
        {
            await _context.EventIdeas.AddAsync(eventIdea);
        }

        public async Task<EventIdea> FindByIdAsync(int id)
        {
            return await _context.EventIdeas.FindAsync(id);
        }

        public void Update(EventIdea eventIdea)
        {
            _context.EventIdeas.Update(eventIdea);
        }
        public void Remove(EventIdea eventIdea)
        {
            _context.EventIdeas.Remove(eventIdea);
        }
    }
}
