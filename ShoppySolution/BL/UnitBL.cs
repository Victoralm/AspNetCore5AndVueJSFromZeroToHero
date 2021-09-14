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
    public class UnitBL : IUnitBL
    {

        private IUnitService _unitService;
        private IMapper _mapper;

        public UnitBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._unitService = serviceProvider.GetRequiredService<IUnitService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public UnitDO Add(UnitDO model)
        {
            UnitDO result = model;
            Unit entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<UnitDO, Unit>(model);
                // Using the UnitService to add the new POCO class object as a new record on the Db Table
                this._unitService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(UnitDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Unit entity = this._mapper.Map<UnitDO, Unit>(model);
                // Using the UnitService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._unitService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public UnitDO GetById(int id)
        {
            UnitDO result = null;

            try
            {
                // Using the UnitService to return a single record from the Db table by Id
                Unit unit = this._unitService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Unit, UnitDO>(unit);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public UnitDO Get(Expression<Func<UnitDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<UnitDO> GetList(Expression<Func<UnitDO, bool>> filter = null)
        {
            List<UnitDO> result = null;

            try
            {
                // Using the UnitService to return a list of records from the Db table
                List<Unit> units = this._unitService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Unit>, List<UnitDO>>(units);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(UnitDO model)
        {
            //UnitDO result = null;
            Unit entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<UnitDO, Unit>(model);
                // Using the UnitService to update a single record from the Db table
                return this._unitService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
