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
    public class WishlistBL : IWishlistBL
    {

        private IWishlistService _wishlistService;
        private IMapper _mapper;

        public WishlistBL(IServiceProvider serviceProvider)
        {
            // Dependency injection
            this._wishlistService = serviceProvider.GetRequiredService<IWishlistService>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public WishlistDO Add(WishlistDO model)
        {
            WishlistDO result = model;
            Wishlist entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<WishlistDO, Wishlist>(model);
                // Using the WishlistService to add the new POCO class object as a new record on the Db Table
                this._wishlistService.Add(entity);
                // Storing the Id to be returned
                result.Id = entity.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Delete(WishlistDO model)
        {
            try
            {
                // Mapping the Domain Object to the POCO class
                Wishlist entity = this._mapper.Map<WishlistDO, Wishlist>(model);
                // Using the WishlistService to delete the new POCO class object from the Db Table, and storing the result of the operation
                bool result = this._wishlistService.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public WishlistDO GetById(int id)
        {
            WishlistDO result = null;

            try
            {
                // Using the WishlistService to return a single record from the Db table by Id
                Wishlist wishlist = this._wishlistService.GetById(id);
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<Wishlist, WishlistDO>(wishlist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public WishlistDO Get(Expression<Func<WishlistDO, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<WishlistDO> GetList(Expression<Func<WishlistDO, bool>> filter = null)
        {
            List<WishlistDO> result = null;

            try
            {
                // Using the WishlistService to return a list of records from the Db table
                List<Wishlist> wishlists = this._wishlistService.GetList();
                // Mapping the POCO class to the Domain Object
                result = this._mapper.Map<List<Wishlist>, List<WishlistDO>>(wishlists);
                if (filter != null)
                    result = result.AsQueryable().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public bool Update(WishlistDO model)
        {
            //WishlistDO result = null;
            Wishlist entity;

            try
            {
                // Mapping the Domain Object to the POCO class
                entity = this._mapper.Map<WishlistDO, Wishlist>(model);
                // Using the WishlistService to update a single record from the Db table
                return this._wishlistService.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
