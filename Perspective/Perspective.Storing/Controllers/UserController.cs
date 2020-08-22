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
        UserRepository UR = new UserRepository();
        public UserController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
           return Ok(UR.GetUser(pc,name));
        }
        [HttpGet("{username},{password}")]
        public IActionResult CheckPassword(string username,string password)
        {
            return Ok(UR.CheckPassword(pc,username,password));
        }
        [HttpPost]
        public IActionResult Add(string name, string password)
        {
           UR.Add(pc,name,password);
           return Ok();
        }
    }
}
