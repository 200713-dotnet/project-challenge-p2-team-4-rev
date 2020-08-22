using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}")]
    public class CatagoryController : ControllerBase 
    {
        private readonly PerspectiveDBContext pc;
        public CatagoryController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        CatagoryRepository CR = new CatagoryRepository();
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(CR.GetAll(pc));
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
           return Ok(CR.GetCatagory(pc,name));
        }
        [HttpPost]
        public IActionResult Add(string name, string description)
        {
           CR.Add(pc,name,description);
           return Ok();
        }
        public IActionResult AddUser(string username,string catagoryname)
        {
           CR.AddUser(pc,username,catagoryname);
           return Ok();
        }
    }
}
