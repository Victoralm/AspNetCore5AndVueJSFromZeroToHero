using Entities;
using Interfaces.BL;
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
            string dbPass = Encryption.Encrypt("1234");
            return View(adminDO);
        }
    }
}
