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
            
            var tempRoom = RoomRepository.Conversion3(RoomRepository.GetRoom(pc,"Movies"),pc);
            
            return Ok(tempRoom);
        }
        [HttpGet("{roomname}")]
        public IActionResult GetMessages(NameModel NM)
        {
            var tempList = RoomRepository.GetMessages(NM.Name);
            return Ok(tempList);
        }
        [HttpPost]
        public IActionResult AddMessage(AddMessageModel AMM)
        {
            MessageRepository.Add(pc,AMM.RoomName,AMM.UserName,AMM.Content);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddUser(AddUserModel AUM)
        {
            RoomRepository.AddUser(pc,AUM.UserName,AUM.roomname);
            return Ok();
        }
    }
}
