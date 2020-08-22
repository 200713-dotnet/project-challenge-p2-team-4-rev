using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}")]
    public class RoomController : ControllerBase 
    {
        private readonly PerspectiveDBContext pc;
        RoomRepository RR =new RoomRepository();
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
    }
}
