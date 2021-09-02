using DapperFantom.Areas.Admin.Models;
using DapperFantom.Entities;
using DapperFantom.Helpers;
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

namespace DapperFantom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthModel] // Dependency injection for the class
    public class ArticleController : Controller
    {
        private ArticleService _articleService;
        private IWebHostEnvironment _hosting;

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
            this._hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Entities.Article article = this._articleService.GetArticleById(id);

            return View(article);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormFile file)
        {
            Entities.Article article = this._articleService.GetArticleById(id);
            
            UploadHelper uploadHelper = new UploadHelper(this._hosting);

            bool result = ( uploadHelper.Delete(article.Image) && (this._articleService.DeleteArticle(article)) );

            if (!result)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(article);
            }

            return RedirectToAction("Index", "Article");
        }
    }
}
