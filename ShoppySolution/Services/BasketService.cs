using DAL.MySqlDbContext;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class BasketService : IBasketService
    {

        public Basket Add(Basket entity)
        {
            Basket basket = null;
            using (var context = new DatabaseContext())
            {
                var addBasket = context.Entry(entity);
                addBasket.State = EntityState.Added;
                context.SaveChanges();
                basket = entity;
            }

            return basket;
        }

        public bool Delete(Basket entity)
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


        public void Update(Basket entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateBasket = context.Entry(entity);
                updateBasket.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Basket GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Basket>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Product)
                    .Include(i => i.User)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Basket Get(Expression<Func<Basket, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Basket>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Basket> GetList(Expression<Func<Basket, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Basket records
                    ? context.Set<Basket>().ToList()
                    // else, return a list of Basket records based on the filter
                    : context.Set<Basket>().Where(filter).ToList();
            }
        }
    }
}
