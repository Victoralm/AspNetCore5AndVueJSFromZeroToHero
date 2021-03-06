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
    public class UnitService : IUnitService
    {
        private readonly DatabaseContext _databaseContext;

        public UnitService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Unit Add(Unit entity)
        {
            Unit unit = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addUnit = context.Entry(entity);
                addUnit.State = EntityState.Added;
                context.SaveChanges();
                unit = entity;
            }

            return unit;
        }

        public bool Delete(Unit entity)
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


        public bool Update(Unit entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateUnit = context.Entry(entity);
                updateUnit.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Unit GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Unit>()
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
        public Unit Get(Expression<Func<Unit, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Unit>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Unit> GetList(Expression<Func<Unit, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Unit records
                    ? context.Set<Unit>().ToList()
                    // else, return a list of Unit records based on the filter
                    : context.Set<Unit>().Where(filter).ToList();
            }
        }
    }
}
