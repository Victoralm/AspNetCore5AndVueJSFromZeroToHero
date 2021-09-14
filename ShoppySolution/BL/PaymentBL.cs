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
    public class PaymentBL : IPaymentBL
    {

        private IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._paymentService = serviceProvider.GetRequiredService<IPaymentService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public PaymentDO Add(PaymentDO model)
        {
            PaymentDO result = model;
            Payment entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<PaymentDO, Payment>(model);
                // Using the PaymentService to add the new POCO class object as a new record on the Db Table
                this._paymentService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(PaymentDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Payment entity = this._mapper.Map<PaymentDO, Payment>(model);
                // Using the PaymentService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._paymentService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PaymentDO GetById(int id)
        {
            PaymentDO result = null;

            try
            {
                // Using the PaymentService to return a single record from the Db table by Id
                Payment payment = this._paymentService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Payment, PaymentDO>(payment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public PaymentDO Get(Expression<Func<PaymentDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<PaymentDO> GetList(Expression<Func<PaymentDO, bool>> filter = null)
        {
            List<PaymentDO> result = null;

            try
            {
                // Using the PaymentService to return a list of records from the Db table
                List<Payment> payments = this._paymentService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Payment>, List<PaymentDO>>(payments);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(PaymentDO model)
        {
            //PaymentDO result = null;
            Payment entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<PaymentDO, Payment>(model);
                // Using the PaymentService to update a single record from the Db table
                return this._paymentService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
