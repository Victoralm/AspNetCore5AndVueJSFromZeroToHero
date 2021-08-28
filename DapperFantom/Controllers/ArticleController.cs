using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Controllers
{
    public class ArticleController : Controller
    {
        private CategoryService _categoryService;

        public object GeneralModel { get; private set; }

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired service class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            List<Category> categList = this._categoryService.GetAllCategDapper();

            GeneralViewModel model = new GeneralViewModel
            {
                CategorieList = categList,
            };

            return View(model);
        }
    }
}
