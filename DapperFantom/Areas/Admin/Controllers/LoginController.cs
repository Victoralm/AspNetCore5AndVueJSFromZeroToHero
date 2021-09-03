using DapperFantom.Services;
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
    public class LoginController : Controller
    {
        private AdminService _adminService;

        public LoginController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._adminService = serviceProvider.GetRequiredService<AdminService>();
        }

        public IActionResult Index()
        {
            Entities.Admin admin = new Entities.Admin();

            return View(admin);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(Entities.Admin adm)
        {
            if (!string.IsNullOrEmpty(adm.Username) || !string.IsNullOrEmpty(adm.Password))
            {
                Entities.Admin admin = this._adminService.Login(adm);
                if (admin == null)
                {
                    ViewBag.Error = "Something went wrong, try it again...";
                    return View(adm);
                }
                // Saving the Cookies
                else
                {
                    CookieOptions userIdCookie = new CookieOptions();
                    userIdCookie.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Append("userId", admin.AdminId.ToString(), userIdCookie);

                    CookieOptions usernameCookie = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(3),
                    };
                    Response.Cookies.Append("username", admin.Username.ToString(), usernameCookie);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = "Please check your username or password...";
                return View(adm);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (Request.Cookies.Count > 0)
            {
                // Removing the Cookies
                foreach (var item in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(item);
                }
            }

            return Redirect("/");
        }
    }
}
