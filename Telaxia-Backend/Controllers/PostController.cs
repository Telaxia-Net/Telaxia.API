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
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new object[] {
                   new{id = 1, title="Boring", description="Making great things today!", 
                       image="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/post-images/post-image-1.jpg", 
                       section="favorites",userPostName="leojavar" },
                   new{id = 2, title="Boring", description="My greatest design",
                       image="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/post-images/post-image-2.jpeg",
                       section="favorites",userPostName="jackyblast" },
                   new{id = 3, title="Amazing!", description="A cutie!",
                       image="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/post-images/post-image-3.jpg",
                       section="favorites",userPostName="robertvim" },
                   new{id = 4, title="Boring", description="Boring!!!!",
                       image="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/post-images/post-image-4.jpg",
                       section="favorites",userPostName="jacksonlow" },
            });
        }
    }
}
