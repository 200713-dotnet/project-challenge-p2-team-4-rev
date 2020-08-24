using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}/{action}")]
    public class CatagoryController : ControllerBase 
    {
        private readonly PerspectiveDBContext pc;

        public CatagoryController(PerspectiveDBContext _db)
        {
            pc = _db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(CatagoryRepository.GetAll());
        }
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
           return Ok(CatagoryRepository.GetCatagory(pc,name));
        }
        [HttpPost]
        public IActionResult Add(string name, string description)
        {
           CatagoryRepository.Add(name,description);
           return Ok();
        }
        [HttpPost]
        public IActionResult AddUser(string username,string catagoryname)
        {
           CatagoryRepository.AddUser(username,catagoryname);
           return Ok();
        }
        
    }
}
