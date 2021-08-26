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
        private PostService _postServ;

        /// <summary>
        /// Injecting IConfiguration as class dependency
        /// </summary>
        /// <param name="config"></param>
        public UserController(IConfiguration config)
        {
            this._userServ = new UserService(config);
            this._postServ = new PostService(config);
        }

        public IActionResult Index()
        {
            #region Checking the cookie
            string cookieUsername = Request.Cookies["username"];
            string cookieUserId = Request.Cookies["userid"];

            if (string.IsNullOrEmpty(cookieUserId) || string.IsNullOrEmpty(cookieUsername))
            {
                return RedirectToAction("Login");
            }
            #endregion
            else
            {
                List<Post> posts = this._postServ.GetPostsByUser(int.Parse(cookieUserId));
                BlogModel model = new BlogModel
                {
                    postList = posts,
                };
                return View(model);
            }
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
                #region Setting the cookie
                CookieOptions userid = new CookieOptions();
                userid.Expires = DateTime.Now.AddDays(5);
                Response.Cookies.Append("userid", myUser.UserId.ToString(), userid);

                CookieOptions username = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(5),
                };
                Response.Cookies.Append("username", myUser.Username, username);
                #endregion


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

        [HttpGet]
        public IActionResult Create()
        {
            BlogModel model = new BlogModel();

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.Publishing_Date = DateTime.Now;
            post.Modified_Date = DateTime.Now;
            post.UserId = int.Parse(Request.Cookies["userid"]);

            bool success = this._postServ.Create(post);
            //bool success = false;
            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error: The Post couldn't be saved...";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Post myPost = this._postServ.GetPost(id);

            // Protecting from error on the id from the browser address
            if (myPost.PostId == 0)
            {
                return RedirectToAction("Index");
            }

            BlogModel model = new BlogModel
            {
                post = myPost,
            };

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Update(Post post)
        {
            post.Modified_Date = DateTime.Now;

            bool success = this._postServ.Update(post);
            //bool success = false;

            if (success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error: The Post couldn't be updated...";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                Post post = this._postServ.GetPost(id);

                if (post != null)
                {
                    BlogModel model = new BlogModel
                    {
                        post = post,
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Delete(BlogModel model)
        {
            bool success = this._postServ.Delete(model.post);

            if (success)
            {
                ViewBag.Success = "Post has been deleted!";
                return View("Deleteit");
            }
            else
            {
                ViewBag.Error = "Error: The Post couldn't be deleted...";
                return View();
            }
        }

        public IActionResult Deleteit(int id)
        {
            bool success = this._postServ.Delete(id);

            if (success)
            {
                ViewBag.Success = "Post has been deleted!";
            }
            else
            {
                ViewBag.Error = "Error: The Post couldn't be deleted...";
            }

            return View();
        }
    }
}
