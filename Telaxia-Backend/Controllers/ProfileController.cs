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
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new object[] {
                   new{id = 111, description=" I love designing clothes and bringing new designs.", rating=4 },
                   new{id = 112, description=" I love creativity", rating=5 },
                   new{id = 113, description=" Search for new things", rating=3 }
            });
        }
    }
}
