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
    public class OrderitemService : IOrderitemService
    {
        private readonly DatabaseContext _databaseContext;

        public OrderitemService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Orderitem Add(Orderitem entity)
        {
            Orderitem orderitem = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addOrderitem = context.Entry(entity);
                addOrderitem.State = EntityState.Added;
                context.SaveChanges();
                orderitem = entity;
            }

            return orderitem;
        }

        public bool Delete(Orderitem entity)
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


        public bool Update(Orderitem entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateOrderitem = context.Entry(entity);
                updateOrderitem.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Orderitem GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Orderitem>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Order)
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
        public Orderitem Get(Expression<Func<Orderitem, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Orderitem>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Orderitem> GetList(Expression<Func<Orderitem, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Orderitem records
                    ? context.Set<Orderitem>().ToList()
                    // else, return a list of Orderitem records based on the filter
                    : context.Set<Orderitem>().Where(filter).ToList();
            }
        }
    }
}
