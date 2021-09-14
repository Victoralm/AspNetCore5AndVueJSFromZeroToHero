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
    public class UserBL : IUserBL
    {

        private IUserService _userService;
        private IMapper _mapper;

        public UserBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._userService = serviceProvider.GetRequiredService<IUserService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public UserDO Add(UserDO model)
        {
            UserDO result = model;
            User entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<UserDO, User>(model);
                // Using the UserService to add the new POCO class object as a new record on the Db Table
                this._userService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(UserDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                User entity = this._mapper.Map<UserDO, User>(model);
                // Using the UserService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._userService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public UserDO GetById(int id)
        {
            UserDO result = null;

            try
            {
                // Using the UserService to return a single record from the Db table by Id
                User user = this._userService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<User, UserDO>(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public UserDO Get(Expression<Func<UserDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<UserDO> GetList(Expression<Func<UserDO, bool>> filter = null)
        {
            List<UserDO> result = null;

            try
            {
                // Using the UserService to return a list of records from the Db table
                List<User> users = this._userService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<User>, List<UserDO>>(users);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(UserDO model)
        {
            //UserDO result = null;
            User entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<UserDO, User>(model);
                // Using the UserService to update a single record from the Db table
                return this._userService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
