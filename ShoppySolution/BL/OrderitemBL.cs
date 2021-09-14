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
    public class OrderitemBL : IOrderitemBL
    {

        private IOrderitemService _orderitemService;
        private IMapper _mapper;

        public OrderitemBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._orderitemService = serviceProvider.GetRequiredService<IOrderitemService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public OrderitemDO Add(OrderitemDO model)
        {
            OrderitemDO result = model;
            Orderitem entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<OrderitemDO, Orderitem>(model);
                // Using the OrderitemService to add the new POCO class object as a new record on the Db Table
                this._orderitemService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(OrderitemDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Orderitem entity = this._mapper.Map<OrderitemDO, Orderitem>(model);
                // Using the OrderitemService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._orderitemService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public OrderitemDO GetById(int id)
        {
            OrderitemDO result = null;

            try
            {
                // Using the OrderitemService to return a single record from the Db table by Id
                Orderitem orderitem = this._orderitemService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Orderitem, OrderitemDO>(orderitem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public OrderitemDO Get(Expression<Func<OrderitemDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<OrderitemDO> GetList(Expression<Func<OrderitemDO, bool>> filter = null)
        {
            List<OrderitemDO> result = null;

            try
            {
                // Using the OrderitemService to return a list of records from the Db table
                List<Orderitem> Orderitems = this._orderitemService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Orderitem>, List<OrderitemDO>>(Orderitems);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(OrderitemDO model)
        {
            //OrderitemDO result = null;
            Orderitem entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<OrderitemDO, Orderitem>(model);
                // Using the OrderitemService to update a single record from the Db table
                return this._orderitemService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
