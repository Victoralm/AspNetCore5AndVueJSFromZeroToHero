using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuth]
    public class AdminController : Controller
    {
        private IAdminBL _adminBl;

        public AdminController(IServiceProvider serviceProvider)
        {
            this._adminBl = serviceProvider.GetRequiredService<IAdminBL>();
        }

        public IActionResult Index()
        {
            List<AdminDO> adminList = this._adminBl.GetList();

            return View(adminList);
        }
    }
}
