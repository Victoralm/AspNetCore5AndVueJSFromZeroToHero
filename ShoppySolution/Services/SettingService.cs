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
    public class SettingService : ISettingService
    {
        private readonly DatabaseContext _databaseContext;

        public SettingService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Setting Add(Setting entity)
        {
            Setting setting = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addSetting = context.Entry(entity);
                addSetting.State = EntityState.Added;
                context.SaveChanges();
                setting = entity;
            }

            return setting;
        }

        public bool Delete(Setting entity)
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


        public bool Update(Setting entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateSetting = context.Entry(entity);
                updateSetting.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Setting GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Setting>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Setting Get(Expression<Func<Setting, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Setting>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Setting> GetList(Expression<Func<Setting, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Setting records
                    ? context.Set<Setting>().ToList()
                    // else, return a list of Setting records based on the filter
                    : context.Set<Setting>().Where(filter).ToList();
            }
        }
    }
}
