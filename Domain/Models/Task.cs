using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlanningAPI.Domain.Models
{
    public class Task
    {
        public int id {get; set;}
        public string description {get; set;}
        public bool done {get; set;} = false;
        public EventIdea eventIdea {get; set;}
        public int eventIdeaId {get; set;}
    }
}