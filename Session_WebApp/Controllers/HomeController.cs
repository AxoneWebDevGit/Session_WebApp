using Microsoft.AspNetCore.Mvc;
using Session_WebApp.Models;
using Session_WebApp.Util;
using System.Diagnostics;

namespace Session_WebApp.Controllers
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
            HttpContext.Session.SetObject("MyObjectKey", new MyObject());
            return View();
        }

        public IActionResult Index1()
        {
            // Create an example object to store in the session
            var myObject = new MyObject
            {
                Property1 = "Value1",
                Property2 = "Value2"
            };

            // Store the object in the session
            HttpContext.Session.SetObject("MyObjectKey", myObject);
            var myObject2 = HttpContext.Session.GetObject<MyObject>("MyObjectKey");
            return View(myObject2);
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
