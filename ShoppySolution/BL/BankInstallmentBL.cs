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
    public class BankInstallmentBL : IBankInstallmentBL
    {

        private IBankInstallmentService _bankInstallmentService;
        private IMapper _mapper;

        public BankInstallmentBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._bankInstallmentService = serviceProvider.GetRequiredService<IBankInstallmentService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BankInstallmentDO Add(BankInstallmentDO model)
        {
            BankInstallmentDO result = model;
            BankInstallment entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BankInstallmentDO, BankInstallment>(model);
                // Using the BankInstallmentService to add the new POCO class object as a new record on the Db Table
                this._bankInstallmentService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(BankInstallmentDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                BankInstallment entity = this._mapper.Map<BankInstallmentDO, BankInstallment>(model);
                // Using the BankInstallmentService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._bankInstallmentService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public BankInstallmentDO GetById(int id)
        {
            BankInstallmentDO result = null;

            try
            {
                // Using the BankInstallmentService to return a single record from the Db table by Id
                BankInstallment bankInstallment = this._bankInstallmentService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<BankInstallment, BankInstallmentDO>(bankInstallment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public BankInstallmentDO Get(Expression<Func<BankInstallmentDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<BankInstallmentDO> GetList(Expression<Func<BankInstallmentDO, bool>> filter = null)
        {
            List<BankInstallmentDO> result = null;

            try
            {
                // Using the BankInstallmentService to return a list of records from the Db table
                List<BankInstallment> bankInstallments = this._bankInstallmentService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<BankInstallment>, List<BankInstallmentDO>>(bankInstallments);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(BankInstallmentDO model)
        {
            //BankInstallmentDO result = null;
            BankInstallment entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BankInstallmentDO, BankInstallment>(model);
                // Using the BankInstallmentService to update a single record from the Db table
                return this._bankInstallmentService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
