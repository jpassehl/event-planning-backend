using AutoMapper;
using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Resources;

namespace EventPlanningAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEventIdeaResource, EventIdea>();
        }
    }
}