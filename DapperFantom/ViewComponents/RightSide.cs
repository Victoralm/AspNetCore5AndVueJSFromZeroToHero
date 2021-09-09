using DapperFantom.Entities;
using DapperFantom.Models;
using DapperFantom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.ViewComponents
{
    public class RightSide : ViewComponent
    {
        private CategoryService _categoryService;
        private ArticleService _articleService;

        public RightSide(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        public IViewComponentResult Invoke()
        {
            List<Category> categoryLst = this._categoryService.GetAllCategAlt();

            // Uses Take to get 4 articles and OrderByDescending to get the ones with greater "Hit" value from Articles Db table
            List<Article> articleLst = this._articleService.GetAllArticlesAlt().Take(4).OrderByDescending(x => x.Hit).ToList();

            GeneralViewModel model = new GeneralViewModel
            {
                CategoryList = categoryLst,
                ArticleList = articleLst,
            };

            foreach (var (category, index) in model.CategoryList.Select((v, i) => (v, i)))
            {
                model.CategoryList[index].ArticleCount = this._articleService.GetTotalArticleCountByCategory(category.CategoryId);
            }

            return View(model);
        }
    }
}
