
namespace EventPlanningAPI.Domain.Models
{
    public class EventIdea
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string ImgUrl {get; set;}
        public IList<Task>? Tasks {get; set;} = new List<Task>();
    }
}