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
    public class ProvinceBL : IProvinceBL
    {

        private IProvinceService _provinceService;
        private IMapper _mapper;

        public ProvinceBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._provinceService = serviceProvider.GetRequiredService<IProvinceService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ProvinceDO Add(ProvinceDO model)
        {
            ProvinceDO result = model;
            Province entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProvinceDO, Province>(model);
                // Using the ProvinceService to add the new POCO class object as a new record on the Db Table
                this._provinceService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(ProvinceDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Province entity = this._mapper.Map<ProvinceDO, Province>(model);
                // Using the ProvinceService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._provinceService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ProvinceDO GetById(int id)
        {
            ProvinceDO result = null;

            try
            {
                // Using the ProvinceService to return a single record from the Db table by Id
                Province province = this._provinceService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Province, ProvinceDO>(province);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public ProvinceDO Get(Expression<Func<ProvinceDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<ProvinceDO> GetList(Expression<Func<ProvinceDO, bool>> filter = null)
        {
            List<ProvinceDO> result = null;

            try
            {
                // Using the ProvinceService to return a list of records from the Db table
                List<Province> provinces = this._provinceService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Province>, List<ProvinceDO>>(provinces);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(ProvinceDO model)
        {
            //ProvinceDO result = null;
            Province entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ProvinceDO, Province>(model);
                // Using the ProvinceService to update a single record from the Db table
                return this._provinceService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
