﻿using DAL.MySqlDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class UserService
    {

        public User Add(User entity)
        {
            User user = null;
            using (var context = new DatabaseContext())
            {
                var addUser = context.Entry(entity);
                addUser.State = EntityState.Added;
                context.SaveChanges();
                user = entity;
            }

            return user;
        }

        public bool Delete(User entity)
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


        public void Update(User entity)
        {
            using (var context = new DatabaseContext())
            {
                var updateUser = context.Entry(entity);
                updateUser.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Does the same as Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<User>()
                    .Where(x => x.Id == id)
                    // Dealing with the relationship of the table
                    .Include(i => i.City)
                    .Include(i => i.Address)
                    .Include(i => i.Baskets)
                    .Include(i => i.Orderitems)
                    .Include(i => i.Orders)
                    .Include(i => i.Payments)
                    .Include(i => i.Resetpasswords)
                    .Include(i => i.Wishlists)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Does the same as GetById
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public User Get(Expression<Func<User, bool>> predicate = null)
        {
            using (var context = new DatabaseContext())
            {
                return context.Set<User>()
                    // If return null, throw an exception
                    .FirstOrDefault(predicate ?? throw new ArgumentException(nameof(predicate)));
            }
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                // If filter is null
                return filter == null
                    // return a list of all User records
                    ? context.Set<User>().ToList()
                    // else, return a list of User records based on the filter
                    : context.Set<User>().Where(filter).ToList();
            }
        }
    }
}