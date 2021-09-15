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
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _databaseContext;

        public ProductService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Product Add(Product entity)
        {
            Product product = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addProduct = context.Entry(entity);
                addProduct.State = EntityState.Added;
                context.SaveChanges();
                product = entity;
            }

            return product;
        }

        public bool Delete(Product entity)
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


        public bool Update(Product entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateProduct = context.Entry(entity);
                updateProduct.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Product>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Brand)
                    .Include(i => i.Category)
                    .Include(i => i.Unit)
                    .Include(i => i.Baskets)
                    .Include(i => i.Orderitems)
                    .Include(i => i.ProductImages)
                    .Include(i => i.Wishlists)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Product Get(Expression<Func<Product, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Product>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Product records
                    ? context.Set<Product>().ToList()
                    // else, return a list of Product records based on the filter
                    : context.Set<Product>().Where(filter).ToList();
            }
        }
    }
}
