using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, CategoryService categoryService)
        {
            _logger = logger;
            this._categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Category> categList = this._categoryService.GetAllCategDapper();

            GeneralViewModel model = new GeneralViewModel
            {
                CategoryList = categList,
            };

            return View(model);
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
