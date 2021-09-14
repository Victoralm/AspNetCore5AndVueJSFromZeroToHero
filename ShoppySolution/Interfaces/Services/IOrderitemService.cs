using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderitemService
    {
        public Orderitem Add(Orderitem entity);

        public bool Delete(Orderitem entity);

        public bool Update(Orderitem entity);

        public Orderitem GetById(int id);

        public Orderitem Get(Expression<Func<Orderitem, bool>> predicate = null);

        public List<Orderitem> GetList(Expression<Func<Orderitem, bool>> filter = null);
    }
}
