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
    class OrderService : IOrderService
    {

        public Order Add(Order entity)
        {
            Order order = null;
            using (var context = new DatabaseContext())
            {
                var addOrder = context.Entry(entity);
                addOrder.State = EntityState.Added;
                context.SaveChanges();
                order = entity;
            }

            return order;
        }

        public bool Delete(Order entity)
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


        public void Update(Order entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateOrder = context.Entry(entity);
                updateOrder.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.DeliveryAddress)
                    .Include(i => i.InvoiceAddress)
                    .Include(i => i.Payment)
                    .Include(i => i.User)
                    .Include(i => i.Orderitems)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Order Get(Expression<Func<Order, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Order>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Order> GetList(Expression<Func<Order, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Order records
                    ? context.Set<Order>().ToList()
                    // else, return a list of Order records based on the filter
                    : context.Set<Order>().Where(filter).ToList();
            }
        }
    }
}
