using System.Threading.Tasks;
using System.Text.Json;
using Perspective.Service.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace Perspective.Service.Controllers
{

  [Route("api/{controller}/{action}")]
  [ApiController]
  public class RoomController : ControllerBase
  {
    

   HttpClient Http = new HttpClient();
   [HttpGet]
   public IActionResult GetRoom()
   {
      ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
      var response = Http.GetAsync($"Http://localhost:5004/api/room/get").GetAwaiter().GetResult();
      var objString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      RoomModel room = JsonConvert.DeserializeObject<RoomModel>(objString);
      return Ok(room);
   }
   [HttpPost]
    public async Task<IActionResult> AddMessage(MessageModel MM)
    {
      ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
      var check = Http.GetAsync($"Http://localhost:5004/api/user/CheckPassword/{MM.UserName}").GetAwaiter().GetResult();
      var flagString = check.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      boolModel flag = JsonConvert.DeserializeObject<boolModel>(flagString);
      if(flag.flag){
      var httpContent = new StringContent(JsonConvert.SerializeObject(new AddMessageModel(){UserName = MM.UserName, Content = MM.Content,Roomname = "Movies"}), Encoding.UTF8,"application/json");
      var response = await Http.PostAsync($"Http://localhost:5004/api/room/AddMessage/",httpContent);
      return Ok();
      }
      else{
      var httpContent = new StringContent(JsonConvert.SerializeObject(new NameModel(){Name = MM.UserName}), Encoding.UTF8,"application/json");
      var failResponse = Http.PostAsync($"Http://localhost:5004/api/user/Add/",httpContent).GetAwaiter().GetResult();
      var httpContent2 = new StringContent(JsonConvert.SerializeObject(new AddMessageModel(){UserName = MM.UserName, Content = MM.Content,Roomname = "Movies"}), Encoding.UTF8,"application/json");
      var response = Http.PostAsync($"Http://localhost:5004/api/room/AddMessage/",httpContent2).GetAwaiter().GetResult();
      return Ok();
      }
    }
    
    [HttpGet]
    public IActionResult test()
    {
      HttpClient client = new HttpClient();
      var response = client.GetAsync("http://localhost:5004/api/catagory/getall").GetAwaiter().GetResult();
      var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      return Ok();
    }

  }
}