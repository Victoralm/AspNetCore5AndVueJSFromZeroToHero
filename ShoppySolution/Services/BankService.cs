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
    public class BankService : IBankService
    {
        private readonly DatabaseContext _databaseContext;

        public BankService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Bank Add(Bank entity)
        {
            Bank bank = null;
            using (DatabaseContext context = this._databaseContext)
            {
                var addBank = context.Entry(entity);
                addBank.State = EntityState.Added;
                context.SaveChanges();
                bank = entity;
            }

            return bank;
        }

        public bool Delete(Bank entity)
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


        public bool Update(Bank entity)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                var updateBank = context.Entry(entity);
                updateBank.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bank GetById(int id)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Bank>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.BankInstallments)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Bank Get(Expression<Func<Bank, bool>> predicate = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                return context.Set<Bank>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Bank> GetList(Expression<Func<Bank, bool>> filter = null)
        {
            using (DatabaseContext context = this._databaseContext)
            {
                // If filter is null
                return filter == null
                    // return a list of all Bank records
                    ? context.Set<Bank>().ToList()
                    // else, return a list of Bank records based on the filter
                    : context.Set<Bank>().Where(filter).ToList();
            }
        }
    }
}
