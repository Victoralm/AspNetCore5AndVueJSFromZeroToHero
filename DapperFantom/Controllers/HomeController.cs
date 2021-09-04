using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        private ArticleService _articleService;

        public HomeController(IServiceProvider serviceProvider, ILogger<HomeController> logger, CategoryService categoryService)
        {
            _logger = logger;

            // Dependency injection as constructor parameter
            this._categoryService = categoryService;

            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        public IActionResult Index()
        {
            List<Category> categList = this._categoryService.GetAllCategDapper();
            List<Article> articleLst = this._articleService.GetHomeArticles();

            GeneralViewModel model = new GeneralViewModel
            {
                ArticleList = articleLst,
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
