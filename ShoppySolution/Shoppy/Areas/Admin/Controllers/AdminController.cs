using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
