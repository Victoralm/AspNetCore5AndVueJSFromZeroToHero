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
    public class BankBL : IBankBL
    {

        private IBankService _bankService;
        private IMapper _mapper;

        public BankBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._bankService = serviceProvider.GetRequiredService<IBankService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public BankDO Add(BankDO model)
        {
            BankDO result = model;
            Bank entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BankDO, Bank>(model);
                // Using the BankService to add the new POCO class object as a new record on the Db Table
                this._bankService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(BankDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Bank entity = this._mapper.Map<BankDO, Bank>(model);
                // Using the BankService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._bankService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public BankDO GetById(int id)
        {
            BankDO result = null;

            try
            {
                // Using the BankService to return a single record from the Db table by Id
                Bank bank = this._bankService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Bank, BankDO>(bank);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public BankDO Get(Expression<Func<BankDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<BankDO> GetList(Expression<Func<BankDO, bool>> filter = null)
        {
            List<BankDO> result = null;

            try
            {
                // Using the BankService to return a list of records from the Db table
                List<Bank> Banks = this._bankService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Bank>, List<BankDO>>(Banks);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(BankDO model)
        {
            //BankDO result = null;
            Bank entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<BankDO, Bank>(model);
                // Using the BankService to update a single record from the Db table
                return this._bankService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
