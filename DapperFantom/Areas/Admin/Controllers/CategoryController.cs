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
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;

        public CategoryController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
        }

        public IActionResult Index()
        {
            List<Category> categoryLst = this._categoryService.GetAllCategDapper();

            UserViewModel model = new UserViewModel
            {
                CategorieList = categoryLst,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Entities.Category categ = new Entities.Category();

            return View(categ);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Entities.Category categ)
        {
            var result = this._categoryService.AddCategory(categ);

            if (result <= 0)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(categ);
            }

            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Entities.Category categ = this._categoryService.GetCategoryById(id);

            return View(categ);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Entities.Category categ)
        {
            Entities.Category result = this._categoryService.UpdateCategory(categ);

            if (result == null)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(categ);
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
