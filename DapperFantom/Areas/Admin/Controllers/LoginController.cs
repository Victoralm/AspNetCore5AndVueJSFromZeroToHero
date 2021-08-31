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
    }
}
