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
        private CityService _cityService;

        public object GeneralModel { get; private set; }

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired service class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
            this._cityService = serviceProvider.GetRequiredService<CityService>();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Add()
        {
            List<Category> categList = this._categoryService.GetAllCategDapper();
            List<City> citList = this._cityService.GetAllCitiesDapper();

            GeneralViewModel model = new GeneralViewModel
            {
                CategorieList = categList,
                CityList = citList,
            };

            return View(model);
        }
    }
}
