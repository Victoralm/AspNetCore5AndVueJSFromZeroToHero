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
    public class BankInstallmentService : IBankInstallmentService
    {
        private readonly DatabaseContext _databaseContext;

        public BankInstallmentService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public BankInstallment Add(BankInstallment entity)
        {
            BankInstallment bankInstallment = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addBankInstallment = context.Entry(entity);
                addBankInstallment.State = EntityState.Added;
                context.SaveChanges();
                bankInstallment = entity;
            }

            return bankInstallment;
        }

        public bool Delete(BankInstallment entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
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


        public bool Update(BankInstallment entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateBankInstallment = context.Entry(entity);
                updateBankInstallment.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankInstallment GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<BankInstallment>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.Bank)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public BankInstallment Get(Expression<Func<BankInstallment, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<BankInstallment>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<BankInstallment> GetList(Expression<Func<BankInstallment, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all BankInstallment records
                    ? context.Set<BankInstallment>().ToList()
                    // else, return a list of BankInstallment records based on the filter
                    : context.Set<BankInstallment>().Where(filter).ToList();
            }
        }
    }
}
