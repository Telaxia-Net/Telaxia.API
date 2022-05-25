using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telaxia_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new object[] {
                   new{UserType= 31, id=11, name="Free", Price="$0" },
                   new{UserType= 31, id=12, name="Pro", Price="$19" },
                   new{UserType= 31, id=13, name="Gigachad", Price="$29" },
                   new{UserType= 31, id=14, name="Picaso", Price="$49" },

                   new{UserType = 32, id=21, name= "Free", Price="$0" },
                   new{UserType = 32, id=22, name= "Collector", Price="$19" },
            });
        }
    }
}
