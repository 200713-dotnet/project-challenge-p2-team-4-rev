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
        
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
           return Ok(UserRepository.GetUser(pc,name));
        }
        [HttpGet("{username},{password}")]
        public IActionResult CheckPassword(string username,string password)
        {
            return Ok(UserRepository.CheckPassword(pc,username,password));
        }
        [HttpPost]
        public IActionResult Add(string name, string password)
        {
           UserRepository.Add(pc,name,password);
           return Ok();
        }
    }
}
