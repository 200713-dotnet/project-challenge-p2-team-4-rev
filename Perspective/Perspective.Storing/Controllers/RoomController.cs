using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}/{action}")]
    public class RoomController : ControllerBase 
    {
        private readonly PerspectiveDBContext pc;

        public RoomController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            
            var tempList = RoomRepository.GetRoom(pc,"Movies");
           return Ok(tempList);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetMessages(string roomname)
        {
            var tempList = RoomRepository.GetMessages(pc,roomname);
            return Ok(tempList);
        }
        [HttpPost]
        public IActionResult AddMessage(string username,string roomname,string content)
        {
            MessageRepository.Add(pc,roomname,username,content);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddUser(string name, string roomname)
        {
            RoomRepository.AddUser(pc,name,roomname);
            return Ok();
        }
    }
}
