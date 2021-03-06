using DAL.MySqlDbContext;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AddressService : IAddressService
    {
        private readonly DatabaseContext _databaseContext;

        public AddressService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Address Add(Address entity)
        {
            Address address = null;
            using (var context = this._databaseContext)
            {
                var addAddress = context.Entry(entity);
                addAddress.State = EntityState.Added;
                context.SaveChanges();
                address = entity;
            }

            return address;
        }

        public bool Delete(Address entity)
        {
            try
            {
                using (DatabaseContext context = this._databaseContext)
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool Update(Address entity)
        {
            using (var context = this._databaseContext)
            {
                var updateAddress = context.Entry(entity);
                updateAddress.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address GetById(int id)
        {
            using (var context = this._databaseContext)
            {
                return context.Set<Address>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.City)
                    .Include(i => i.User)
                    .Include(i => i.OrderDeliveryAddresses)
                    .Include(i => i.OrderInvoiceAddresses)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Address Get(Expression<Func<Address, bool>> predicate = null)
        {
            using (var context = this._databaseContext)
            {
                return context.Set<Address>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Address> GetList(Expression<Func<Address, bool>> filter = null)
        {
            using (var context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Address records
                    ? context.Set<Address>().ToList()
                    // else, return a list of Address records based on the filter
                    : context.Set<Address>().Where(filter).ToList();
            }
        }
    }
}
