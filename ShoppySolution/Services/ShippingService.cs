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
    public class ShippingService : IShippingService
    {

        public Shipping Add(Shipping entity)
        {
            Shipping shipping = null;
            using (var context = new DatabaseContext())
            {
                var addShipping = context.Entry(entity);
                addShipping.State = EntityState.Added;
                context.SaveChanges();
                shipping = entity;
            }

            return shipping;
        }

        public bool Delete(Shipping entity)
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


        public bool Update(Shipping entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateShipping = context.Entry(entity);
                updateShipping.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Shipping GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Shipping>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Payments)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Shipping Get(Expression<Func<Shipping, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Shipping>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Shipping> GetList(Expression<Func<Shipping, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Shipping records
                    ? context.Set<Shipping>().ToList()
                    // else, return a list of Shipping records based on the filter
                    : context.Set<Shipping>().Where(filter).ToList();
            }
        }
    }
}
