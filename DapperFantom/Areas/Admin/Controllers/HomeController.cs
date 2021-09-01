using DapperFantom.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthModel] // Dependency injection for the class
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
