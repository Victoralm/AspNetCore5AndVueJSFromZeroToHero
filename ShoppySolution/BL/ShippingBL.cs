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
    public class ShippingBL : IShippingBL
    {

        private IShippingService _shippingService;
        private IMapper _mapper;

        public ShippingBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._shippingService = serviceProvider.GetRequiredService<IShippingService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ShippingDO Add(ShippingDO model)
        {
            ShippingDO result = model;
            Shipping entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ShippingDO, Shipping>(model);
                // Using the ShippingService to add the new POCO class object as a new record on the Db Table
                this._shippingService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(ShippingDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Shipping entity = this._mapper.Map<ShippingDO, Shipping>(model);
                // Using the ShippingService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._shippingService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ShippingDO GetById(int id)
        {
            ShippingDO result = null;

            try
            {
                // Using the ShippingService to return a single record from the Db table by Id
                Shipping shipping = this._shippingService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Shipping, ShippingDO>(shipping);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public ShippingDO Get(Expression<Func<ShippingDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<ShippingDO> GetList(Expression<Func<ShippingDO, bool>> filter = null)
        {
            List<ShippingDO> result = null;

            try
            {
                // Using the ShippingService to return a list of records from the Db table
                List<Shipping> shippings = this._shippingService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Shipping>, List<ShippingDO>>(shippings);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(ShippingDO model)
        {
            //ShippingDO result = null;
            Shipping entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ShippingDO, Shipping>(model);
                // Using the ShippingService to update a single record from the Db table
                return this._shippingService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
