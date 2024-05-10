using AutoMapper;
using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Resources;
using Task = EventPlanningAPI.Domain.Models.Task;

namespace EventPlanningAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<EventIdea,EventIdeaResource>();
            CreateMap<Task, TaskResource>();
        }
    }
}