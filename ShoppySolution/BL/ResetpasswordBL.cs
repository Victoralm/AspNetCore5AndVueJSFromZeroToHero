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
    public class ResetpasswordBL : IResetpasswordBL
    {

        private IResetpasswordService _resetpasswordService;
        private IMapper _mapper;

        public ResetpasswordBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._resetpasswordService = serviceProvider.GetRequiredService<IResetpasswordService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public ResetpasswordDO Add(ResetpasswordDO model)
        {
            ResetpasswordDO result = model;
            Resetpassword entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ResetpasswordDO, Resetpassword>(model);
                // Using the ResetpasswordService to add the new POCO class object as a new record on the Db Table
                this._resetpasswordService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(ResetpasswordDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Resetpassword entity = this._mapper.Map<ResetpasswordDO, Resetpassword>(model);
                // Using the ResetpasswordService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._resetpasswordService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public ResetpasswordDO GetById(int id)
        {
            ResetpasswordDO result = null;

            try
            {
                // Using the ResetpasswordService to return a single record from the Db table by Id
                Resetpassword resetpassword = this._resetpasswordService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Resetpassword, ResetpasswordDO>(resetpassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public ResetpasswordDO Get(Expression<Func<ResetpasswordDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<ResetpasswordDO> GetList(Expression<Func<ResetpasswordDO, bool>> filter = null)
        {
            List<ResetpasswordDO> result = null;

            try
            {
                // Using the ResetpasswordService to return a list of records from the Db table
                List<Resetpassword> resetpasswords = this._resetpasswordService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Resetpassword>, List<ResetpasswordDO>>(resetpasswords);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(ResetpasswordDO model)
        {
            //ResetpasswordDO result = null;
            Resetpassword entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<ResetpasswordDO, Resetpassword>(model);
                // Using the ResetpasswordService to update a single record from the Db table
                return this._resetpasswordService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
