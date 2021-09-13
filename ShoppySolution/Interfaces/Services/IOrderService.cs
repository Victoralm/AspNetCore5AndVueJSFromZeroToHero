using DAL.MySqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderService
    {
        public Order Add(Order entity);

        public bool Delete(Order entity);

        public void Update(Order entity);

        public Order GetById(int id);

        public Order Get(Expression<Func<Order, bool>> predicate = null);

        public List<Order> GetList(Expression<Func<Order, bool>> filter = null);
    }
}
