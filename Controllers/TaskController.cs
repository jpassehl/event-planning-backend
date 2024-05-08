using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace EventPlanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
        }

        [HttpGet("")]
        public IEnumerable<string> Getstrings()
        {
            return new string[] {"task1", "task2", "task3" };
        }
    }

}