using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Perspective.Service.Models;
//using Newtonsoft.Json;
using System.Collections.Generic;

namespace Perspective.Service.Controllers
{

  [Route("api/{controller}/{action}")]
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
    [HttpGet]
    public IActionResult test()
    {
      HttpClient client = new HttpClient();
      var response = client.GetAsync("http://localhost:5004/api/catagory/getall").GetAwaiter().GetResult();
      var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      //CategoryModel[] bsObj = JsonConvert.DeserializeObject<CategoryModel[]>(jsonString);
      return Ok(jsonString);
    }

  }
}