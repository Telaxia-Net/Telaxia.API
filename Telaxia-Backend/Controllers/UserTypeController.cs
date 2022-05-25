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
    public class UserTypeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new object[] {
                   new{id = 31, type="Designer" },
                   new{id = 32, type="Buyer" }
            });
        }
    }
}
