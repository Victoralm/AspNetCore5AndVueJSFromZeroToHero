using DapperFantom.Entities;
using DapperFantom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperFantom.Controllers
{
    public class CommentController : Controller
    {
        private CommentService _commentService;
        private ArticleService _articleService;

        public CommentController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._commentService = serviceProvider.GetRequiredService<CommentService>();
            this._articleService = serviceProvider.GetRequiredService<ArticleService>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(string id, IFormCollection form)
        {
            Article article = new Article();
            int result = 0;

            try
            {
                article = this._articleService.GetArticleByGuid(id);

                Comment comment = new Comment
                {
                    ArticleId = article.ArticleId,
                    Name = form["commentName"],
                    Email = form["commentEmail"],
                    CommentText = form["commentMessage"],
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Status = 1,
                };

                result = this._commentService.AddComment(comment);

                if (result > 0)
                {
                    return Ok(new { success = "true" });
                }
                else
                {
                    return Ok(new { success = "false" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return View();
        }
    }
}
