﻿using DAL.MySqlDbContext;
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
    public class ResetpasswordService : IResetpasswordService
    {
        private readonly DatabaseContext _databaseContext;

        public ResetpasswordService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Resetpassword Add(Resetpassword entity)
        {
            Resetpassword resetpassword = null;
            using (DatabaseContext context = new DatabaseContext())
            {
                var addResetpassword = context.Entry(entity);
                addResetpassword.State = EntityState.Added;
                context.SaveChanges();
                resetpassword = entity;
            }

            return resetpassword;
        }

        public bool Delete(Resetpassword entity)
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


        public bool Update(Resetpassword entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updateResetpassword = context.Entry(entity);
                updateResetpassword.State = EntityState.Modified;
                return context.SaveChanges() >= 1 ? true : false;
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Resetpassword GetById(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Resetpassword>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.User)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Resetpassword Get(Expression<Func<Resetpassword, bool>> predicate = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Resetpassword>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<Resetpassword> GetList(Expression<Func<Resetpassword, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all Resetpassword records
                    ? context.Set<Resetpassword>().ToList()
                    // else, return a list of Resetpassword records based on the filter
                    : context.Set<Resetpassword>().Where(filter).ToList();
            }
        }
    }
}
