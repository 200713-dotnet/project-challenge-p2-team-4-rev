using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Perspective.Storing
{
    [ApiController]
    [Route("/api/{Controller}")]
    public class MessageController : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var mm = new MessageModel();
            HttpClient client = new HttpClient();
            var response =await client.GetAsync("http://localhost:5000/api/Message");
            var mm2 = response.Content;

            return Ok(mm);
        }
    }
}