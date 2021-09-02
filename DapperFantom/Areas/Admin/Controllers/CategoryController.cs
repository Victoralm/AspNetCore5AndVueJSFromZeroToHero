﻿using DapperFantom.Areas.Admin.Models;
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
    }
}
