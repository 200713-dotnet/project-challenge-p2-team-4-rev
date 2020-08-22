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
        RoomRepository RR =new RoomRepository();
        CatagoryRepository CR = new CatagoryRepository();
        public RoomController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        [HttpGet("{Catagory}")]
        public IActionResult Get(string catagory)
        {
            
            var tempList = RR.GetCategory(pc,catagory);
           return Ok(tempList);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetMessages(string roomname)
        {
            var tempList = RR.GetMessages(pc,roomname);
            return Ok(tempList);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetTopic(string roomname)
        {
            Room rm = RR.GetRoom(pc,roomname);
            return Ok(CR.GetTopic(pc,rm.Catagory.Name));
        }
        [HttpPost]
        public IActionResult AddMessage(string username,string roomname,string content)
        {
            RR.add(pc,roomname,username,content);
            return Ok();
        }
        
    }
}
