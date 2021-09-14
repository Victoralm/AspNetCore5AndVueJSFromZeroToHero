using AutoMapper;
using DAL.MySqlDbContext;
using Entities;
using Interfaces.BL;
using Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SliderBL : ISliderBL
    {

        private ISliderService _sliderService;
        private IMapper _mapper;

        public SliderBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._sliderService = serviceProvider.GetRequiredService<ISliderService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public SliderDO Add(SliderDO model)
        {
            SliderDO result = model;
            Slider entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<SliderDO, Slider>(model);
                // Using the SliderService to add the new POCO class object as a new record on the Db Table
                this._sliderService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(SliderDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Slider entity = this._mapper.Map<SliderDO, Slider>(model);
                // Using the SliderService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._sliderService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public SliderDO GetById(int id)
        {
            SliderDO result = null;

            try
            {
                // Using the SliderService to return a single record from the Db table by Id
                Slider slider = this._sliderService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Slider, SliderDO>(slider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public SliderDO Get(Expression<Func<SliderDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<SliderDO> GetList(Expression<Func<SliderDO, bool>> filter = null)
        {
            List<SliderDO> result = null;

            try
            {
                // Using the SliderService to return a list of records from the Db table
                List<Slider> sliders = this._sliderService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Slider>, List<SliderDO>>(sliders);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(SliderDO model)
        {
            //SliderDO result = null;
            Slider entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<SliderDO, Slider>(model);
                // Using the SliderService to update a single record from the Db table
                return this._sliderService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
