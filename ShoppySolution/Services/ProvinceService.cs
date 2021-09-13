using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class ProvinceService : IProvinceService
    {

        public Province Add(Province entity)
        {
            Province province = null;
            using (var context = new DatabaseContext())
            {
                var addProvince = context.Entry(entity);
                addProvince.State = EntityState.Added;
                context.SaveChanges();
                province = entity;
            }

            return province;
        }

        public bool Delete(Province entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Deleted;
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


        public void Update(Province entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateProvince = context.Entry(entity);
                updateProvince.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Province GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Province>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Cities)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Province Get(Expression<Func<Province, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Province>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Province> GetList(Expression<Func<Province, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Province records
                    ? context.Set<Province>().ToList()
                    // else, return a list of Province records based on the filter
                    : context.Set<Province>().Where(filter).ToList();
            }
        }
    }
}
