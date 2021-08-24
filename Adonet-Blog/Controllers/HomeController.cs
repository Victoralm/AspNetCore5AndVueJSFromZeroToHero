﻿using Adonet_Blog.Entities;
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
            List<Post> posts = new List<Post>();
            posts = this._postService.GetAllPosts();

            return View(posts);
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
