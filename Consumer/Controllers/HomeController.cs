using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Consumer.Messages.Recevie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Consumer.Models;

namespace Consumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IUserMessageRecevier _recevier;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // _recevier = recevier;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [HttpGet]
        // [Route("/users")]
        // public IActionResult ReceiveMessage()
        // {
        //     return PartialView(_recevier.Receive());
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}