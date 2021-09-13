using DAL.MySqlDbContext;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class AdminService : IAdminService
    {

        public Admin Add(Admin entity)
        {
            Admin admin = null;
            using (var context = new DatabaseContext())
            {
                var addAdmin = context.Entry(entity);
                addAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                admin = entity;
            }

            return admin;
        }

        public bool Delete(Admin entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
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


        public void Update(Admin entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateAdmin = context.Entry(entity);
                updateAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin GetById(int id)
        {
            using (var context = new DatabaseContext())
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
            using (var context = new DatabaseContext())
            {
                return context.Set<Admin>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
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
