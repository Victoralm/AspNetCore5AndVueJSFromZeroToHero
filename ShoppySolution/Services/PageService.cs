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
    public class PageService : IPageService
    {
        private readonly DatabaseContext _databaseContext;

        public PageService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Page Add(Page entity)
        {
            Page page = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addPage = context.Entry(entity);
                addPage.State = EntityState.Added;
                context.SaveChanges();
                page = entity;
            }

            return page;
        }

        public bool Delete(Page entity)
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


        public bool Update(Page entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updatePage = context.Entry(entity);
                updatePage.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Page GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Page>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Page Get(Expression<Func<Page, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Page>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Page> GetList(Expression<Func<Page, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Page records
                    ? context.Set<Page>().ToList()
                    // else, return a list of Page records based on the filter
                    : context.Set<Page>().Where(filter).ToList();
            }
        }
    }
}
