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
    public class BasketBL : IBasketBL
    {

        private IBasketService _basketService;
        private IMapper _mapper;

        public BasketBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._basketService = serviceProvider.GetRequiredService<IBasketService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BasketDO Add(BasketDO model)
        {
            BasketDO result = model;
            Basket entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BasketDO, Basket>(model);
                // Using the BasketService to add the new POCO class object as a new record on the Db Table
                this._basketService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(BasketDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Basket entity = this._mapper.Map<BasketDO, Basket>(model);
                // Using the BasketService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._basketService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public BasketDO GetById(int id)
        {
            BasketDO result = null;

            try
            {
                // Using the BasketService to return a single record from the Db table by Id
                Basket basket = this._basketService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Basket, BasketDO>(basket);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public BasketDO Get(Expression<Func<BasketDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<BasketDO> GetList(Expression<Func<BasketDO, bool>> filter = null)
        {
            List<BasketDO> result = null;

            try
            {
                // Using the BasketService to return a list of records from the Db table
                List<Basket> baskets = this._basketService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Basket>, List<BasketDO>>(baskets);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(BasketDO model)
        {
            //BasketDO result = null;
            Basket entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BasketDO, Basket>(model);
                // Using the BasketService to update a single record from the Db table
                return this._basketService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
