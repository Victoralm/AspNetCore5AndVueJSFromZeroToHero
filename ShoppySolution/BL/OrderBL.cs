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
    public class OrderBL : IOrderBL
    {

        private IOrderService _orderService;
        private IMapper _mapper;

        public OrderBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._orderService = serviceProvider.GetRequiredService<IOrderService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public OrderDO Add(OrderDO model)
        {
            OrderDO result = model;
            Order entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<OrderDO, Order>(model);
                // Using the OrderService to add the new POCO class object as a new record on the Db Table
                this._orderService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(OrderDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Order entity = this._mapper.Map<OrderDO, Order>(model);
                // Using the OrderService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._orderService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public OrderDO GetById(int id)
        {
            OrderDO result = null;

            try
            {
                // Using the OrderService to return a single record from the Db table by Id
                Order order = this._orderService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Order, OrderDO>(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public OrderDO Get(Expression<Func<OrderDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<OrderDO> GetList(Expression<Func<OrderDO, bool>> filter = null)
        {
            List<OrderDO> result = null;

            try
            {
                // Using the OrderService to return a list of records from the Db table
                List<Order> orders = this._orderService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Order>, List<OrderDO>>(orders);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(OrderDO model)
        {
            //OrderDO result = null;
            Order entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<OrderDO, Order>(model);
                // Using the OrderService to update a single record from the Db table
                return this._orderService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
