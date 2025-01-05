using System.ComponentModel.DataAnnotations;

namespace EventPlanningAPI.Resources
{
    public class SaveEventIdeaResource
    {
        [Required]
        public string Name {get;set;}
        [Required]
        public string Description {get;set;}
        public string? ImgUrl{get;set;}
    }
}