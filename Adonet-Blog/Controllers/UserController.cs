using Adonet_Blog.Entities;
using Adonet_Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(User user)
        {
            BlogModel model = new BlogModel
            {
                user = new User(),
            };
            return View();
        }
    }
}
