using AutoMapper;
using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Resources;
using Task = EventPlanningAPI.Domain.Models.Task;

namespace EventPlanningAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEventIdeaResource, EventIdea>();
            CreateMap<TaskResource, Task>();
        }
    }
}