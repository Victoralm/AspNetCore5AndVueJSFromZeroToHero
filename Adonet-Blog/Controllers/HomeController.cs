using Adonet_Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace Adonet_Blog.Controllers
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
            List<Person> persons = new List<Person>
            {
                new Person()
                {
                    Name = "Victor",
                    Surname = "Almeida"
                },
                new Person()
                {
                    Name = "Caio",
                    Surname = "Argolo"
                }
            };

            return View(persons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Acessado como: https://localhost:44303/Home/AboutUs
        public IActionResult AboutUs()
        {
            return View();
        }
        
        // With custom layout template
        public IActionResult AboutUs2()
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
