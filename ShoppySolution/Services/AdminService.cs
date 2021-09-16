using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService : IAdminService
    {
        private DatabaseContext _databaseContext;

        public AdminService(IServiceProvider serviceProvider)
        {
            this._databaseContext = serviceProvider.GetRequiredService<DatabaseContext>();
        }

        public Admin Add(Admin entity)
        {
            Admin admin = null;
            try
            {
                using (var context = new DatabaseContext())
                {
                    //var addAdmin = context.AddAsync(entity);
                    var addAdmin = context.Entry(entity);
                    addAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    var savedRes = context.SaveChanges();
                    admin = entity;
                }
                //var addAdmin = this._databaseContext.Entry(entity);
                //addAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                //var savedRes = this._databaseContext.SaveChanges();
                //admin = entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return admin;
        }

        public bool Delete(Admin entity)
        {
            try
            {
                using (DatabaseContext context = this._databaseContext)
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool Update(Admin entity)
        {
            using (var context = this._databaseContext)
            {
                var updateAdmin = context.Entry(entity);
                updateAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin GetById(int id)
        {
            using (var context = this._databaseContext)
            {
                return context.Set<Admin>().Where(x => x.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Admin Get(Expression<Func<Admin, bool>> predicate = null)
        {
            try
            {
                using (var context = this._databaseContext)
                {
                    return context.Set<Admin>()
                        // If return null, throw an exception
                        .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null)
        {
            using (var context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Admin records
                    ? context.Set<Admin>().ToList()
                    // else, return a list of Admin records based on the filter
                    : context.Set<Admin>().Where(filter).ToList();
            }
        }
    }
}
