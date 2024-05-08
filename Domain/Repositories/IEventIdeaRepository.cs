using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanningAPI.Domain.Models;


namespace EventPlanningAPI.Domain.Repositories
{
    public interface IEventIdeaRepository
    {
         Task<IEnumerable<EventIdea>> ListAsync();
    }
}