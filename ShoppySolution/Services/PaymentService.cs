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
    class PaymentService : IPaymentService
    {

        public Payment Add(Payment entity)
        {
            Payment payment = null;
            using (var context = new DatabaseContext())
            {
                var addPayment = context.Entry(entity);
                addPayment.State = EntityState.Added;
                context.SaveChanges();
                payment = entity;
            }

            return payment;
        }

        public bool Delete(Payment entity)
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


        public void Update(Payment entity)
        {
            using (var context = new DatabaseContext())
            {
                var updatePayment = context.Entry(entity);
                updatePayment.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Payment GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Payment>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Shipping)
                    .Include(i => i.User)
                    .Include(i => i.Orders)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Payment Get(Expression<Func<Payment, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<Payment>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Payment> GetList(Expression<Func<Payment, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Payment records
                    ? context.Set<Payment>().ToList()
                    // else, return a list of Payment records based on the filter
                    : context.Set<Payment>().Where(filter).ToList();
            }
        }
    }
}
