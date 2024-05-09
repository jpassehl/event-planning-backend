using EventPlanningAPI.Domain.Models;

namespace EventPlanningAPI.Resources
{
    public class TaskResource
    {
        public int Id {get; set;}
        public string Description {get; set;}
        public bool Done {get; set;}
        public EventIdeaResource eventIdea {get; set;}
    }
}