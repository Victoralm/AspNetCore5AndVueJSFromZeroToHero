using DapperFantom.Areas.Admin.Models;
using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthModel] // Dependency injection for the class
    public class ArticleController : Controller
    {
        private ArticleService _articleService;

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        public IActionResult Index()
        {
            List<Article> articleLst = this._articleService.GetAllArticles();

            UserViewModel model = new UserViewModel
            {
                ArticleList = articleLst,
            };

            return View(model);
        }
    }
}
