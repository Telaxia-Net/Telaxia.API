using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telaxia_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new object[] {
                   new{id = 111, username="leojavar",password="1234", UserImage="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/users-images/jenny_walters.jpg" , phone=987612345,mail="mendoza19@gmail.com",planID=12},
                   new{id = 112,  username="admin",password="1234", UserImage="https://raw.githubusercontent.com/Fabrizio-2025/image-store/main/users-images/admin.jpg" , phone=987616545,mail="admin22@gmail.com",planID=21}
            });
        }
    }
}
