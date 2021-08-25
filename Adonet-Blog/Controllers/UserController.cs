using Adonet_Blog.Entities;
using Adonet_Blog.Models;
using Adonet_Blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonet_Blog.Controllers
{
    public class UserController : Controller
    {
        private UserService _userServ;

        /// <summary>
        /// Injecting IConfiguration as class dependency
        /// </summary>
        /// <param name="config"></param>
        public UserController(IConfiguration config)
        {
            this._userServ = new UserService(config);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel
            {
                User = new User(),
                Success = true,
            };
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Login(User formUser)
        {
            LoginModel model = new LoginModel
            {
                User = new User(),
            };

            User myUser = this._userServ.Login(formUser);

            if (myUser.UserId > 0 && myUser.Username != string.Empty && myUser.Password != string.Empty)
            {
                CookieOptions userid = new CookieOptions();
                userid.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Append("userid", myUser.UserId.ToString(), userid);

                CookieOptions username = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(5),
                };
                Response.Cookies.Append("username", myUser.Username, username);


                return RedirectToAction("Index");
            }
            else
            {
                model = new LoginModel
                {
                    User = new User(),
                    Success = false,
                    Message = "Please check your username and password",
                };
                return View("Login", model);
            }

            
        }
    }
}
