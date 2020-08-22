using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Perspective.Service.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    

   HttpClient Http = new HttpClient();
   [HttpGet]
    public async Task<IActionResult> Get(string name)
    {
      var response = await Http.GetAsync($"Http://localhost:5002/api/category/get/{name}");
      return Ok(response.Content);
    }

    [HttpPost]
    public async Task<IActionResult> add(string name, string description)
    {
      var response = await Http.GetAsync($"Http://localhost:5002/api/category/add/{name}/{description}");
      return Ok(response.Content);
    }

  }
}