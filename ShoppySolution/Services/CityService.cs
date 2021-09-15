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
    public class CityService : ICityService
    {
        private readonly DatabaseContext _databaseContext;

        public CityService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public City Add(City entity)
        {
            City City = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addCity = context.Entry(entity);
                addCity.State = EntityState.Added;
                context.SaveChanges();
                City = entity;
            }

            return City;
        }

        public bool Delete(City entity)
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


        public bool Update(City entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateCity = context.Entry(entity);
                updateCity.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<City>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Province)
                    .Include(i => i.Addresses)
                    .Include(i => i.Users)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public City Get(Expression<Func<City, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<City>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<City> GetList(Expression<Func<City, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all City records
                    ? context.Set<City>().ToList()
                    // else, return a list of City records based on the filter
                    : context.Set<City>().Where(filter).ToList();
            }
        }
    }
}
