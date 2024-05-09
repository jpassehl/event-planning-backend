using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventPlanningAPI.Domain.Models;
using EventPlanningAPI.Resources;

namespace EventPlanningAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<EventIdea,EventIdeaResource>();
        }
    }
}