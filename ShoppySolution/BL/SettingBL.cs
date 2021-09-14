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
    public class SettingBL : ISettingBL
    {

        private ISettingService _settingService;
        private IMapper _mapper;

        public SettingBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._settingService = serviceProvider.GetRequiredService<ISettingService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public SettingDO Add(SettingDO model)
        {
            SettingDO result = model;
            Setting entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<SettingDO, Setting>(model);
                // Using the SettingService to add the new POCO class object as a new record on the Db Table
                this._settingService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(SettingDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Setting entity = this._mapper.Map<SettingDO, Setting>(model);
                // Using the SettingService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._settingService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public SettingDO GetById(int id)
        {
            SettingDO result = null;

            try
            {
                // Using the SettingService to return a single record from the Db table by Id
                Setting setting = this._settingService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Setting, SettingDO>(setting);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public SettingDO Get(Expression<Func<SettingDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<SettingDO> GetList(Expression<Func<SettingDO, bool>> filter = null)
        {
            List<SettingDO> result = null;

            try
            {
                // Using the SettingService to return a list of records from the Db table
                List<Setting> settings = this._settingService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Setting>, List<SettingDO>>(settings);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(SettingDO model)
        {
            //SettingDO result = null;
            Setting entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<SettingDO, Setting>(model);
                // Using the SettingService to update a single record from the Db table
                return this._settingService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
