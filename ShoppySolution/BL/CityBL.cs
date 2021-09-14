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
    public class CityBL : ICityBL
    {

        private ICityService _cityService;
        private IMapper _mapper;

        public CityBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._cityService = serviceProvider.GetRequiredService<ICityService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public CityDO Add(CityDO model)
        {
            CityDO result = model;
            City entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<CityDO, City>(model);
                // Using the CityService to add the new POCO class object as a new record on the Db Table
                this._cityService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(CityDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                City entity = this._mapper.Map<CityDO, City>(model);
                // Using the CityService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._cityService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public CityDO GetById(int id)
        {
            CityDO result = null;

            try
            {
                // Using the CityService to return a single record from the Db table by Id
                City city = this._cityService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<City, CityDO>(city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public CityDO Get(Expression<Func<CityDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<CityDO> GetList(Expression<Func<CityDO, bool>> filter = null)
        {
            List<CityDO> result = null;

            try
            {
                // Using the CityService to return a list of records from the Db table
                List<City> cities = this._cityService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<City>, List<CityDO>>(cities);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(CityDO model)
        {
            //CityDO result = null;
            City entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<CityDO, City>(model);
                // Using the CityService to update a single record from the Db table
                return this._cityService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
