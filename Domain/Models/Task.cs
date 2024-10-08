using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanningAPI.Domain.Models
{
    public class Task
    {
        public int Id {get; set;}
        public string Description {get; set;}
        public bool Done {get; set;} = false;
        public EventIdea EventIdea {get; set;}
        public int EventIdeaId {get; set;}
    }
}