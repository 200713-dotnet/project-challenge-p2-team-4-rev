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
        
        public UserController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        
        [HttpGet("{username}")]
        public IActionResult CheckPassword(string username)
        {
            return Ok(UserRepository.CheckUser(pc,username));
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
           UserRepository.Add(pc,name);
           return Ok();
        }
    }
}
