using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminBL : IAdminBL
    {

        private IAdminService _adminService;
        private IMapper _mapper;

        public AdminBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._adminService = serviceProvider.GetRequiredService<IAdminService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public AdminDO Add(AdminDO model)
        {
            AdminDO result = model;
            Admin entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<AdminDO, Admin>(model);
                // Using the AdminService to add the new POCO class object as a new record on the Db Table
                this._adminService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(AdminDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Admin entity = this._mapper.Map<AdminDO, Admin>(model);
                // Using the AdminService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._adminService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public AdminDO GetById(int id)
        {
            AdminDO result = null;

            try
            {
                // Using the AdminService to return a single record from the Db table by Id
                Admin admin = this._adminService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Admin, AdminDO>(admin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public AdminDO Get(Expression<Func<AdminDO, bool>> predicate = null)
        {
            AdminDO result = null;
            List<AdminDO> adminDOLst = null;

            try
            {
                // Using the AdminService to return a list of records from the Db table
                List<Admin> admins = this._adminService.GetList();
                // Mapping the POCO class to the Domain Object
                adminDOLst = this._mapper.Map<List<Admin>, List<AdminDO>>(admins);
                if (predicate != null)
                    result = adminDOLst.AsQueryable().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public List<AdminDO> GetList(Expression<Func<AdminDO, bool>> filter = null)
        {
            List<AdminDO> result = null;

            try
            {
                // Using the AdminService to return a list of records from the Db table
                List<Admin> admins = this._adminService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Admin>, List<AdminDO>>(admins);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public AdminDO Login(AdminDO model)
        {
            AdminDO result = null;

            try
            {
                // Using the AdminService to return a single record from the Db table by Id
                Admin admin = this._adminService.Get(x => x.Username == model.Username);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Admin, AdminDO>(admin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(AdminDO model)
        {
            //AdminDO result = null;
            Admin entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<AdminDO, Admin>(model);
                // Using the AdminService to update a single record from the Db table
                return this._adminService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
