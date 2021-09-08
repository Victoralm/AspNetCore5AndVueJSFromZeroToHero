using DapperFantom.Entities;
using DapperFantom.Helpers;
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
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;
        private ArticleService _articleService;
        private IServiceProvider _serviceProvider;

        public CategoryController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        [Route("/Category/{slug}/{page?}")]
        public IActionResult Index(string slug, int page = 1)
        {
            if (!string.IsNullOrEmpty(slug))
            {
                Category categ = this._categoryService.GetCategoryBySlug(slug);
                List<Category> categLst = this._categoryService.GetAllCategAlt();
                PaginationHelper paginationHelper = new PaginationHelper(this._serviceProvider);
                PaginationModel paginationModel = paginationHelper.CategoryPagination(categ, page);
                if (categ != null)
                {
                    //List<Article> articleLst = this._articleService.GetArticlesByCategoryId(categ.CategoryId);

                    GeneralViewModel model = new GeneralViewModel
                    {
                        //ArticleList = articleLst,
                        PaginationModel = paginationModel,
                        CategoryList = categLst,
                    };

                    return View(model);
                }
                else
                    return Redirect("/");
            }
            else
                return Redirect("/");
        }
    }
}
