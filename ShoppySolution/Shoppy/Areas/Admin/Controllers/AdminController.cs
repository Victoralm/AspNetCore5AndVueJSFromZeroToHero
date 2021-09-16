using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shoppy.Areas.Admin.Models;
using Shoppy.Extensions;
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

        [HttpGet]
        public IActionResult Create()
        {
            AdminDO adminDO = new AdminDO();

            return View(adminDO);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Create(AdminDO adminDO)
       {
            try
            {
                AdminDO usernameCheck = this._adminBl.Get(x => x.Username == adminDO.Username);
                //AdminDO usernameCheck = this._adminBl.Login(adminDO);
                if (usernameCheck != null)
                {
                    ViewBag.Error = "This username is already in use. Please, try another one...";
                    return View(adminDO);
                }

                adminDO.CreatedAt = DateTime.Now;
                adminDO.UpdatedAt = DateTime.Now;
                adminDO.Authority = 5;
                adminDO.Password = Encryption.Encrypt(adminDO.Password);

                AdminDO addAdminDO = this._adminBl.Add(adminDO);

                if (addAdminDO != null)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Error = "Something went wrong, please try again...";
                    return View(adminDO);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewBag.Error = "Something went wrong, please try again...";
                return View(adminDO);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                AdminDO result = this._adminBl.GetById(id);
                ViewBag.Pass = Encryption.Decrypt(result.Password);
                return View(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
