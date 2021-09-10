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

namespace DapperFantom.Controllers
{
    public class ArticleController : Controller
    {
        private CategoryService _categoryService;
        private CityService _cityService;
        private ArticleService _articleService;
        private IWebHostEnvironment _hosting;
        private CommentService _commentService;

        public object GeneralModel { get; private set; }

        public ArticleController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._categoryService = serviceProvider.GetRequiredService<CategoryService>();
            this._cityService = serviceProvider.GetRequiredService<CityService>();
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
            this._hosting = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            this._commentService = serviceProvider.GetRequiredService<CommentService>();
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
                CategoryList = categList,
                CityList = citList,
                Article = new Article(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    //string filename = await uploadHelper.Upload(file);
                    string filename = await uploadHelper.Upload(file);
                    if (!string.IsNullOrEmpty(filename))
                    {
                        model.Image = filename;
                    }
                }

                // Stores the ID of the artivle
                int result = this._articleService.Add(model);

                if (result > 0)
                {
                    //return RedirectToAction("Add");
                    Article article = this._articleService.GetArticleById(result);
                    return RedirectToAction("Detail", new { id = article.Guid });
                }
                else
                {
                    string message = "Something went wrong, please check it...";
                    return View(message);
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


        public IActionResult Detail(string id)
        {
            //Article article = this._articleService.GetArticleById(id);
            Article article = this._articleService.GetArticleByGuid(id);
            Article prevArticle = this._articleService.GetPrevArticleById(article.ArticleId);
            Article nextArticle = this._articleService.GetNextArticleById(article.ArticleId);
            List <Category> catLst = this._categoryService.GetAllCategAlt();

            List<Comment> commentLst = this._commentService.GetAllCommntsFromArticle(article.ArticleId);

            GeneralViewModel model = new GeneralViewModel
            {
                Article = article,
                CategoryList = catLst,
                PrevArticle = prevArticle,
                NextArticle = nextArticle,
                CommentList = commentLst,
            };

            this._articleService.IncreaseHit(model.Article.ArticleId);

            foreach (var (category, index) in model.CategoryList.Select((v, i) => (v, i)))
            {
                model.CategoryList[index].ArticleCount = this._articleService.GetTotalArticleCountByCategory(category.CategoryId);
            }

            return View(model);
        }
    }
}
