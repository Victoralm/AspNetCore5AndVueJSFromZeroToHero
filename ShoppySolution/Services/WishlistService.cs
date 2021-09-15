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
    public class WishlistService : IWishlistService
    {
        private readonly DatabaseContext _databaseContext;

        public WishlistService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Wishlist Add(Wishlist entity)
        {
            Wishlist wishlist = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addWishlist = context.Entry(entity);
                addWishlist.State = EntityState.Added;
                context.SaveChanges();
                wishlist = entity;
            }

            return wishlist;
        }

        public bool Delete(Wishlist entity)
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


        public bool Update(Wishlist entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateWishlist = context.Entry(entity);
                updateWishlist.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wishlist GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Wishlist>()
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
        public Wishlist Get(Expression<Func<Wishlist, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Wishlist>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Wishlist> GetList(Expression<Func<Wishlist, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Wishlist records
                    ? context.Set<Wishlist>().ToList()
                    // else, return a list of Wishlist records based on the filter
                    : context.Set<Wishlist>().Where(filter).ToList();
            }
        }
    }
}
