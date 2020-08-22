using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}")]
    public class UserController : ControllerBase 
    {
        private readonly PerspectiveDBContext pc;
        
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok();
        }
    }
}
