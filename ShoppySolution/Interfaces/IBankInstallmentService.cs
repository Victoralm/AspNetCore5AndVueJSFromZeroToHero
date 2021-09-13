using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAdminService
    {
        public Admin Add(Admin entity);

        public bool Delete(Admin entity);

        public void Update(Admin entity);

        public Admin GetById(int id);

        public Admin Get(Expression<Func<Admin, bool>> predicate = null);

        public List<Admin> GetList(Expression<Func<Admin, bool>> filter = null);
    }
}
