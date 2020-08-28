using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Perpective.Client.Models;
using Newtonsoft.Json;
using System.Text;

namespace Perpective.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/api/room/getroom").GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            ViewBag.room = JsonConvert.DeserializeObject<RoomModel>(jsonString);
            ViewBag.Space = " ";
            return View();
        }
        public IActionResult AddMessage(RoomViewModel RVM)
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            HttpClient client = new HttpClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(new MessageModel(){UserName = RVM.textName, Content = RVM.message}), Encoding.UTF8,"application/json");
            client.PostAsync("http://localhost:5000/api/room/AddMessage", httpContent).GetAwaiter().GetResult();;
            var response = client.GetAsync("http://localhost:5000/api/room/getroom").GetAwaiter().GetResult();
            var jsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            ViewBag.room = JsonConvert.DeserializeObject<RoomModel>(jsonString);
            ViewBag.Space = " ";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
