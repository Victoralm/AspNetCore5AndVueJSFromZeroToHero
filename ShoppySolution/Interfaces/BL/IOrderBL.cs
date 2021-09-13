using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.BL
{
    public interface IOrderBL
    {
        OrderDO Add(OrderDO model);
        OrderDO Update(OrderDO model);
        bool Delete(OrderDO model);
        OrderDO GetById(int id);
        OrderDO GetById(Expression<Func<OrderDO, bool>> predicate = null);
        List<OrderDO> GetList(Expression<Func<OrderDO, bool>> filter = null);
    }
}
