﻿using DapperFantom.Areas.Admin.Models;
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
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Entities.Admin adm)
        {
            return View();
        }
    }
}