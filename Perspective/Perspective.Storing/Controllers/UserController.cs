using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}/{action}")]
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
            
            return Ok(new BoolModel{flag = UserRepository.CheckUser(pc,username)});
        }
        [HttpPost]
        public IActionResult Add(NameModel NM)
        {
           UserRepository.Add(pc,NM.Name);
           return Ok();
        }
    }
}
