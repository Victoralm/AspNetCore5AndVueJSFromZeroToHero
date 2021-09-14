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
    public class BrandBL : IBrandBL
    {

        private IBrandService _brandService;
        private IMapper _mapper;

        public BrandBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._brandService = serviceProvider.GetRequiredService<IBrandService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BrandDO Add(BrandDO model)
        {
            BrandDO result = model;
            Brand entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BrandDO, Brand>(model);
                // Using the BrandService to add the new POCO class object as a new record on the Db Table
                this._brandService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(BrandDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Brand entity = this._mapper.Map<BrandDO, Brand>(model);
                // Using the BrandService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._brandService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public BrandDO GetById(int id)
        {
            BrandDO result = null;

            try
            {
                // Using the BrandService to return a single record from the Db table by Id
                Brand brand = this._brandService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Brand, BrandDO>(brand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public BrandDO Get(Expression<Func<BrandDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<BrandDO> GetList(Expression<Func<BrandDO, bool>> filter = null)
        {
            List<BrandDO> result = null;

            try
            {
                // Using the BrandService to return a list of records from the Db table
                List<Brand> brands = this._brandService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Brand>, List<BrandDO>>(brands);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(BrandDO model)
        {
            //BrandDO result = null;
            Brand entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BrandDO, Brand>(model);
                // Using the BrandService to update a single record from the Db table
                return this._brandService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
