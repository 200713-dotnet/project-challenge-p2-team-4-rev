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
        
        [HttpGet("{Catagory}")]
        public IActionResult Get(string catagory)
        {
            
            var tempList = RoomRepository.GetCategory(pc,catagory);
           return Ok(tempList);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetMessages(string roomname)
        {
            var tempList = RoomRepository.GetMessages(pc,roomname);
            return Ok(tempList);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetTopic(string roomname)
        {
            Room rm = RoomRepository.GetRoom(pc,roomname);
            return Ok(CatagoryRepository.GetTopic(rm.Catagory.Name));
        }
        [HttpPost]
        public IActionResult AddMessage(string username,string roomname,string content)
        {
            RoomRepository.add(pc,roomname,username,content);
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
