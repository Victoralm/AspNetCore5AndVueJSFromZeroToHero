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
    public class BrandService : IBrandService
    {
        private readonly DatabaseContext _databaseContext;

        public BrandService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Brand Add(Brand entity)
        {
            Brand brand = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addBrand = context.Entry(entity);
                addBrand.State = EntityState.Added;
                context.SaveChanges();
                brand = entity;
            }

            return brand;
        }

        public bool Delete(Brand entity)
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


        public bool Update(Brand entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateBrand = context.Entry(entity);
                updateBrand.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Brand>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Products)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Brand Get(Expression<Func<Brand, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Brand>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Brand> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Brand records
                    ? context.Set<Brand>().ToList()
                    // else, return a list of Brand records based on the filter
                    : context.Set<Brand>().Where(filter).ToList();
            }
        }
    }
}
