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
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Category Add(Category entity)
        {
            Category Category = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addCategory = context.Entry(entity);
                addCategory.State = EntityState.Added;
                context.SaveChanges();
                Category = entity;
            }

            return Category;
        }

        public bool Delete(Category entity)
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


        public bool Update(Category entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateCategory = context.Entry(entity);
                updateCategory.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Category>()
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
        public Category Get(Expression<Func<Category, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Category>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Category records
                    ? context.Set<Category>().ToList()
                    // else, return a list of Category records based on the filter
                    : context.Set<Category>().Where(filter).ToList();
            }
        }
    }
}
