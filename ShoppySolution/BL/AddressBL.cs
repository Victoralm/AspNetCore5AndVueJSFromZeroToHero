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
    public class AddressBL : IAddressBL
    {

        private IAddressService _addressService;
        private IMapper _mapper;

        public AddressBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._addressService = serviceProvider.GetRequiredService<IAddressService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public AddressDO Add(AddressDO model)
        {
            AddressDO result = model;
            Address entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<AddressDO, Address>(model);
                // Using the AddressService to add the new POCO class object as a new record on the Db Table
                this._addressService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(AddressDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Address entity = this._mapper.Map<AddressDO, Address>(model);
                // Using the AddressService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._addressService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public AddressDO GetById(int id)
        {
            AddressDO result = null;

            try
            {
                // Using the AddressService to return a single record from the Db table by Id
                Address Address = this._addressService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Address, AddressDO>(Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public AddressDO Get(Expression<Func<AddressDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<AddressDO> GetList(Expression<Func<AddressDO, bool>> filter = null)
        {
            List<AddressDO> result = null;

            try
            {
                // Using the AddressService to return a list of records from the Db table
                List<Address> Addresss = this._addressService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Address>, List<AddressDO>>(Addresss);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(AddressDO model)
        {
            //AddressDO result = null;
            Address entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<AddressDO, Address>(model);
                // Using the AddressService to update a single record from the Db table
                return this._addressService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
