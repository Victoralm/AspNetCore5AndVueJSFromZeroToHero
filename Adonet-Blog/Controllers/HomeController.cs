using Adonet_Blog.Entities;
using Adonet_Blog.Models;
using Adonet_Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Adonet_Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        PostService _postService;

        /// <summary>
        /// Injetando um ILogger (de tipo HomeController) e um IServiceProvider como dependência
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceProvider"></param>
        public HomeController(ILogger<HomeController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;

            // Inicializando _postService com a injeção de dependência
            this._postService = new PostService(serviceProvider);
        }

        public IActionResult Index()
        {
            #region Instanciando e inicializando
            //BlogModel model = new BlogModel();
            //model.postList = this._postService.GetAllPosts();
            #endregion

            #region Iniciando na instanciação
            BlogModel model = new BlogModel
            {
                postList = this._postService.GetAllPosts()
            };
            #endregion

            return View(model);
        }

        public IActionResult PostDetail(int id)
        {
            Post myPost = this._postService.GetPost(id);
            BlogModel model = new BlogModel
            {
                post = myPost
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Acessado como: https://localhost:44303/Home/AboutUs
        public IActionResult AboutUs()
        {
            return View();
        }
        
        // With custom layout template
        public IActionResult AboutUs2()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
