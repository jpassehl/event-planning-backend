
namespace EventPlanningAPI.Resources
{
    public class EventIdeaResource
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get;set;}
        public string ImgUrl {get;set;}
        public IList<TaskResource>? Tasks {get; set;}
    }
}