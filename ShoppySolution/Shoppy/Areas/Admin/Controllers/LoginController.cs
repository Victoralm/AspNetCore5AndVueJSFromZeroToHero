using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private IAdminBL _adminBL;

        public LoginController(IServiceProvider serviceProvider)
        {
            this._adminBL = serviceProvider.GetRequiredService<IAdminBL>();
        }
        
        public IActionResult Index()
        {
            AdminDO adminDO = new AdminDO();
            //string dbPass = Encryption.Encrypt("1234");
            return View(adminDO);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(AdminDO adminDO)
        {
            if (adminDO != null && adminDO.Username.Length > 3 && adminDO.Password.Length > 3)
            {
                AdminDO loginDO = this._adminBL.Login(adminDO);
                if (loginDO != null)
                {
                    string dbPass = Encryption.Decrypt(loginDO.Password);
                    if (dbPass == adminDO.Password)
                    {
                        // Cookie generation
                        CookieOptions useridCookie = new CookieOptions();
                        useridCookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Append("userid", loginDO.Id.ToString(), useridCookie);
                        CookieOptions usernameCookie = new CookieOptions() 
                        {
                            Expires = DateTime.Now.AddDays(3),
                        };
                        Response.Cookies.Append("username", loginDO.Username, usernameCookie);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Something went wrong, try again...";
                        return View(adminDO);
                    }
                }
                else
                {
                    ViewBag.Error = "Something went wrong, try again...";
                    return View(adminDO);
                }
            }
            else
            {
                ViewBag.Error = "Something went wrong, try again...";
                return View(adminDO);
            }
        }
    }
}
