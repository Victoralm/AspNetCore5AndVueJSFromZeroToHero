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
    public class SliderService : ISliderService
    {
        private readonly DatabaseContext _databaseContext;

        public SliderService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Slider Add(Slider entity)
        {
            Slider slider = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addSlider = context.Entry(entity);
                addSlider.State = EntityState.Added;
                context.SaveChanges();
                slider = entity;
            }

            return slider;
        }

        public bool Delete(Slider entity)
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


        public bool Update(Slider entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateSlider = context.Entry(entity);
                updateSlider.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Slider GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Slider>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Slider Get(Expression<Func<Slider, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Slider>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Slider> GetList(Expression<Func<Slider, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Slider records
                    ? context.Set<Slider>().ToList()
                    // else, return a list of Slider records based on the filter
                    : context.Set<Slider>().Where(filter).ToList();
            }
        }
    }
}
