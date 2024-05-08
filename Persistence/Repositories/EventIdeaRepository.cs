using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Domain.Repositories;
using EventPlanningAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Persistence.Repositories
{
    public class EventIdeaRepository : BaseRepository, IEventIdeaRepository
    {
        public EventIdeaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventIdea>> ListAsync()
        {
            return await _context.EventIdeas.ToListAsync();
        }
    }
}