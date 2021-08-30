using DapperFantom.Entities;
using DapperFantom.Helper;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private IWebHostEnvironment _hosting;

        public object GeneralModel { get; private set; }

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
            this._cityService = serviceProvider.GetRequiredService<CityService>();
            this._hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categList = this._categoryService.GetAllCategDapper();
            List<City> citList = this._cityService.GetAllCitiesDapper();

            GeneralViewModel model = new GeneralViewModel
            {
                CategorieList = categList,
                CityList = citList,
                Article = new Article(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Article model, IFormFile file)
        {
            if(ModelState.IsValid)
            {
                Guid guid = Guid.NewGuid();
                model.Guid = guid.ToString();
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.PublishedDate = DateTime.Now;
                if(file.Length > 0)
                {
                    UploadHelper uploadHelper = new UploadHelper(this._hosting);
                    string filename = await uploadHelper.Upload(file);
                    if(!string.IsNullOrEmpty(filename))
                    {
                        model.Image = filename;
                    }
                }
            }
            else
            {
                var message = string.Join("|", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
            }
            return View();
        }
    }
}
