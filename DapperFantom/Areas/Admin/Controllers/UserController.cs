using DapperFantom.Areas.Admin.Models;
using DapperFantom.Models;
using DapperFantom.Services;
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
    public class UserController : Controller
    {
        private AdminService _adminService;

        public UserController(IServiceProvider serviceProvider)
        {
            // Does de correct dependency injection of the desired class
            // An alternative to injecting as a parameter on the constructor
            this._adminService = serviceProvider.GetRequiredService<AdminService>();
        }

        public IActionResult Index()
        {
            List<Entities.Admin> userList = this._adminService.GetAllUsers();

            var model = new UserViewModel
            {
                UserList = userList,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Entities.Admin admin = new Entities.Admin();

            return View(admin);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Entities.Admin adm)
        {
            var result = this._adminService.AddUser(adm);

            if (result <= 0)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(adm);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Entities.Admin admin = this._adminService.GetUserById(id);

            return View(admin);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Entities.Admin adm)
        {
            Entities.Admin result = this._adminService.UpdateUser(adm);

            if (result == null)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(adm);
            }

            return RedirectToAction("Index", "User");
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Entities.Admin admin = this._adminService.GetUserById(id);

            return View(admin);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Entities.Admin adm)
        {
            bool result = this._adminService.DeleteUser(adm);

            if (!result)
            {
                ViewBag.Error = "Something went wrong please try it again...";
                return View(adm);
            }

            return RedirectToAction("Index", "User");
        }
    }
}
