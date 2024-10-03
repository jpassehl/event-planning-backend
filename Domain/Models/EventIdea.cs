
namespace EventPlanningAPI.Domain.Models
{
    public class EventIdea
    {
        public int id {get; set;}
        public string name {get; set;}
        public string description {get; set;}
        public string imgUrl {get; set;}
        public IList<Task> tasks {get; set;} = new List<Task>();
    }
}