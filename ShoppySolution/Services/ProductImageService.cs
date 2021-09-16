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
    public class ProductImageService : IProductImageService
    {
        private readonly DatabaseContext _databaseContext;

        public ProductImageService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public ProductImage Add(ProductImage entity)
        {
            ProductImage productImage = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addProductImage = context.Entry(entity);
                addProductImage.State = EntityState.Added;
                context.SaveChanges();
                productImage = entity;
            }

            return productImage;
        }

        public bool Delete(ProductImage entity)
        {
            try
            {
                using (DatabaseContext context = this._databaseContext)
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


        public bool Update(ProductImage entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateProductImage = context.Entry(entity);
                updateProductImage.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductImage GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<ProductImage>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Product)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public ProductImage Get(Expression<Func<ProductImage, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<ProductImage>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<ProductImage> GetList(Expression<Func<ProductImage, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all ProductImage records
                    ? context.Set<ProductImage>().ToList()
                    // else, return a list of ProductImage records based on the filter
                    : context.Set<ProductImage>().Where(filter).ToList();
            }
        }
    }
}
