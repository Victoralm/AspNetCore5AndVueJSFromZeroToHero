using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class AdminService
    {

        public Admin Add(Admin entity)
        {
            Admin admin = null;
            using (var context = new DatabaseContext())
            {
                var addAdmin = context.Entry(entity);
                addAdmin.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                admin = entity;
            }

            return admin;
        }

        public bool Delete(Admin entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var deleteEntity = context.Entry(entity);
                    deleteEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
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

    }
}
